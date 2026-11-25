namespace FastFoodPOS;

public partial class HistoryForm : Form
{
    private Font voidFont;
    private bool ready;
    private bool filling;

    public HistoryForm()
    {
        InitializeComponent();
        Theme.Apply(this);
        AcceptButton = btnSearch;
    }

    private void HistoryForm_Load(object sender, EventArgs e)
    {
        voidFont = new Font(dgvOrders.Font, FontStyle.Strikeout);

        dtpFrom.Value = DateTime.Today.AddDays(-30);
        dtpTo.Value = DateTime.Today;
        rbAll.Checked = true;

        ready = true;
        ApplyFilter(null);
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        if (voidFont != null) voidFont.Dispose();
        base.OnFormClosed(e);
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        if (dtpFrom.Value.Date > dtpTo.Value.Date)
        {
            MessageBox.Show("The start date must not be after the end date.", App.Title,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dtpFrom.Focus();
            return;
        }
        ApplyFilter(null);
    }

    private void Payment_CheckedChanged(object sender, EventArgs e)
    {
        if (!ready || !((RadioButton)sender).Checked) return;
        ApplyFilter(null);
    }

    private void txtOrderId_KeyPress(object sender, KeyPressEventArgs e)
    {

        if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            e.Handled = true;
    }

    private void ApplyFilter(Order keep)
    {
        DateTime from = dtpFrom.Value.Date;
        DateTime to = dtpTo.Value.Date.AddDays(1);
        string payment = rbCash.Checked ? "Cash" : rbCard.Checked ? "Card" : null;

        int id = 0;
        bool byId = int.TryParse(txtOrderId.Text.Trim(), out id);

        List<Order> found = DataStore.Orders
            .Where(o => o.Date >= from && o.Date < to)
            .Where(o => payment == null || o.Payment == payment)
            .Where(o => !byId || o.Id == id)
            .OrderByDescending(o => o.Id)
            .ToList();

        filling = true;
        dgvOrders.Rows.Clear();
        foreach (Order order in found)
        {
            int r = dgvOrders.Rows.Add(Fmt.Int(order.Id), Fmt.Stamp(order.Date), Fmt.Money(order.Subtotal),
                                       Fmt.Money(order.Tax), Fmt.Money(order.Total), order.Payment, order.Status);
            DataGridViewRow row = dgvOrders.Rows[r];
            row.Tag = order;

            if (order.IsVoided)
            {
                row.DefaultCellStyle.ForeColor = Color.Gray;
                row.DefaultCellStyle.Font = voidFont;
            }
        }

        dgvOrders.ClearSelection();
        DataGridViewRow toSelect = null;
        foreach (DataGridViewRow row in dgvOrders.Rows)
            if (keep != null && ReferenceEquals(row.Tag, keep)) toSelect = row;
        if (toSelect == null && dgvOrders.Rows.Count > 0) toSelect = dgvOrders.Rows[0];
        if (toSelect != null)
        {
            toSelect.Selected = true;
            dgvOrders.CurrentCell = toSelect.Cells[0];
        }
        filling = false;

        ShowLines();

        List<Order> paid = found.Where(o => !o.IsVoided).ToList();
        if (found.Count == 0)
            lblSummary.Text = "No orders match the filter";
        else
            lblSummary.Text = paid.Count + (paid.Count == 1 ? " paid order" : " paid orders")
                              + "   |   Revenue " + Fmt.Money(paid.Sum(o => o.Total));
    }

    private Order SelectedOrder()
    {
        if (dgvOrders.SelectedRows.Count == 0) return null;
        return dgvOrders.SelectedRows[0].Tag as Order;
    }

    private void dgvOrders_SelectionChanged(object sender, EventArgs e)
    {
        if (!ready || filling) return;
        ShowLines();
    }

    private void ShowLines()
    {
        Order order = SelectedOrder();

        dgvLines.Rows.Clear();
        if (order != null)
        {
            foreach (OrderLine line in order.Lines)
                dgvLines.Rows.Add(line.Item, line.ExtrasText, Fmt.Int(line.Qty), Fmt.Money(line.UnitPrice), Fmt.Money(line.Total));
        }

        bool has = order != null;
        btnReprint.Enabled = has;
        btnVoid.Enabled = has;
        btnDelete.Enabled = has && Session.IsAdmin;
        grpLines.Text = has ? "Items in order #" + order.Id : "Items in the selected order";
    }

    private void btnReprint_Click(object sender, EventArgs e)
    {
        Order order = SelectedOrder();
        if (order == null) return;

        using (ReceiptForm receipt = new ReceiptForm(order))
            receipt.ShowDialog(this);
    }

    private void btnVoid_Click(object sender, EventArgs e)
    {
        Order order = SelectedOrder();
        if (order == null) return;

        if (!order.IsVoided)
        {
            DialogResult answer = MessageBox.Show("Void order #" + order.Id + "? It will no longer count as revenue.",
                App.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer != DialogResult.Yes) return;
        }

        order.Status = order.IsVoided ? "Paid" : "Voided";
        ApplyFilter(order);
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        Order order = SelectedOrder();
        if (order == null) return;

        DialogResult answer = MessageBox.Show("Delete order #" + order.Id + " permanently?", App.Title,
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (answer != DialogResult.Yes) return;

        DataStore.DeleteOrder(order);
        ApplyFilter(null);
    }

    private void HistoryForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape) Close();
    }
}
