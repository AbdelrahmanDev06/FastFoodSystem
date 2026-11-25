namespace FastFoodPOS;

public partial class OrderForm : Form
{

    private readonly List<OrderLine> cart = new List<OrderLine>();

    private bool rebuilding;
    private bool loadingExtras;
    private string statusNote = "";

    public OrderForm()
    {
        InitializeComponent();
        Theme.Apply(this);
    }

    private void OrderForm_Load(object sender, EventArgs e)
    {
        cmbCategory.Items.Clear();
        cmbCategory.Items.Add("All");
        foreach (string category in DataStore.Categories)
            cmbCategory.Items.Add(category);

        BuildExtraBoxes();

        cmbCategory.SelectedIndex = 0;
        RefreshCart(null);

        SetNote("Tap a menu item to add it to the order.   Ctrl+F = search   Ctrl+Enter = checkout");
        txtSearch.Focus();
    }

    private void BuildExtraBoxes()
    {
        flpExtras.Controls.Clear();
        foreach (AddOn addOn in DataStore.AddOns)
        {
            CheckBox box = new CheckBox();
            box.Text = addOn.Name + " (+" + Fmt.Money(addOn.Price) + ")";
            box.Tag = addOn.Name;
            box.AutoSize = true;
            box.Margin = new Padding(0, 0, 24, 8);
            box.CheckedChanged += Extra_CheckedChanged;
            flpExtras.Controls.Add(box);
        }
    }

    private void RefreshMenu()
    {
        string category = cmbCategory.SelectedItem as string ?? "All";
        string search = txtSearch.Text.Trim();

        flpMenu.SuspendLayout();
        while (flpMenu.Controls.Count > 0)
            flpMenu.Controls[0].Dispose();

        foreach (MenuItemInfo item in DataStore.Items)
        {
            if (!item.Available) continue;
            if (category != "All" && item.Category != category) continue;
            if (search.Length > 0 && !item.Name.Contains(search, StringComparison.OrdinalIgnoreCase)) continue;

            MenuTile tile = new MenuTile(item);
            tile.Click += Tile_Click;
            tile.MouseEnter += Tile_MouseEnter;
            tile.MouseLeave += Tile_MouseLeave;
            flpMenu.Controls.Add(tile);
        }

        if (flpMenu.Controls.Count == 0)
        {
            Label none = new Label();
            none.Text = "No menu items match.";
            none.AutoSize = true;
            none.ForeColor = Color.Gray;
            none.Margin = new Padding(12);
            flpMenu.Controls.Add(none);
        }

        flpMenu.ResumeLayout();
    }

    private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshMenu();
    }

    private void txtSearch_TextChanged(object sender, EventArgs e)
    {
        RefreshMenu();
    }

    private void Tile_Click(object sender, EventArgs e)
    {
        MenuTile tile = (MenuTile)sender;
        AddToCart(tile.Item);
    }

    private void Tile_MouseEnter(object sender, EventArgs e)
    {
        MenuTile tile = (MenuTile)sender;
        lblNote.Text = tile.Item.Name + "  -  " + Fmt.Money(tile.Item.Price) + "  (" + tile.Item.Category + ")   click to add";
    }

    private void Tile_MouseLeave(object sender, EventArgs e)
    {
        lblNote.Text = statusNote;
    }

    private void AddToCart(MenuItemInfo item)
    {

        OrderLine line = cart.FirstOrDefault(l => l.Item == item.Name && l.Extras.Count == 0);
        if (line == null)
        {
            line = new OrderLine { Item = item.Name, Category = item.Category, BasePrice = item.Price, Qty = 0 };
            cart.Add(line);
        }

        if (line.Qty >= 99)
        {
            SetNote("The maximum quantity per line is 99.");
            return;
        }

        line.Qty++;
        RefreshCart(line);
    }

    private OrderLine SelectedLine()
    {
        if (dgvCart.SelectedRows.Count == 0) return null;
        return dgvCart.SelectedRows[0].Tag as OrderLine;
    }

    private void RefreshCart(OrderLine select)
    {
        rebuilding = true;
        dgvCart.Rows.Clear();
        foreach (OrderLine line in cart)
        {
            int r = dgvCart.Rows.Add(line.Item, line.ExtrasText, Fmt.Int(line.Qty), Fmt.Money(line.UnitPrice), Fmt.Money(line.Total));
            dgvCart.Rows[r].Tag = line;
        }

        dgvCart.ClearSelection();
        if (select != null)
        {
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (ReferenceEquals(row.Tag, select))
                {
                    row.Selected = true;
                    dgvCart.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }
        rebuilding = false;

        UpdateExtrasPanel();
        UpdateTotals();
    }

    private void dgvCart_SelectionChanged(object sender, EventArgs e)
    {
        if (rebuilding) return;
        UpdateExtrasPanel();
    }

    private void dgvCart_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete)
        {
            btnRemove.PerformClick();
            e.Handled = true;
        }
    }

    private void UpdateTotals()
    {
        decimal subtotal = cart.Sum(l => l.Total);
        decimal tax = Math.Round(subtotal * DataStore.TaxRate, 2);

        lblSubtotal.Text = Fmt.Money(subtotal);
        lblTax.Text = Fmt.Money(tax);
        lblTotal.Text = Fmt.Money(subtotal + tax);

        btnExtras.Enabled = btnRemove.Enabled = btnClear.Enabled = cart.Count > 0;
    }

    private void UpdateExtrasPanel()
    {
        OrderLine line = SelectedLine();

        loadingExtras = true;
        grpExtras.Enabled = line != null;
        foreach (CheckBox box in flpExtras.Controls.OfType<CheckBox>())
            box.Checked = line != null && line.Extras.Contains((string)box.Tag);
        numQty.Value = line != null ? line.Qty : 1;
        loadingExtras = false;
    }

    private void Extra_CheckedChanged(object sender, EventArgs e)
    {
        if (loadingExtras) return;
        OrderLine line = SelectedLine();
        if (line == null) return;

        line.SetExtras(flpExtras.Controls.OfType<CheckBox>().Where(b => b.Checked).Select(b => (string)b.Tag));
        RefreshCart(line);
    }

    private void numQty_ValueChanged(object sender, EventArgs e)
    {
        if (loadingExtras) return;
        OrderLine line = SelectedLine();
        if (line == null) return;

        line.Qty = (int)numQty.Value;
        RefreshCart(line);
    }

    private void btnExtras_Click(object sender, EventArgs e)
    {
        if (SelectedLine() == null)
        {
            MessageBox.Show("Select a line in the order first, then tick its extras.", App.Title,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        CheckBox first = flpExtras.Controls.OfType<CheckBox>().FirstOrDefault();
        if (first != null) first.Focus();
        SetNote("Tick the extras for the selected line in the panel below the menu.");
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
        OrderLine line = SelectedLine();
        if (line == null)
        {
            SetNote("Select a line in the order to remove it.");
            return;
        }

        int index = cart.IndexOf(line);
        cart.Remove(line);
        OrderLine next = cart.Count == 0 ? null : cart[Math.Min(index, cart.Count - 1)];
        RefreshCart(next);
        SetNote("Line removed.");
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        if (cart.Count == 0) return;

        DialogResult answer = MessageBox.Show("Remove every line from the current order?", App.Title,
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (answer != DialogResult.Yes) return;

        cart.Clear();
        RefreshCart(null);
        SetNote("Order cleared.");
    }

    private void btnCheckout_Click(object sender, EventArgs e)
    {

        if (cart.Count == 0)
        {
            MessageBox.Show("The order is empty. Tap a menu item first.", App.Title,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string payment = rbCard.Checked ? "Card" : "Cash";
        decimal subtotal = cart.Sum(l => l.Total);
        decimal total = subtotal + Math.Round(subtotal * DataStore.TaxRate, 2);

        DialogResult answer = MessageBox.Show("Take " + payment.ToLower() + " payment of " + Fmt.Money(total) + "?",
            "Checkout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (answer != DialogResult.Yes) return;

        Order order = DataStore.PlaceOrder(cart, payment);

        cart.Clear();
        RefreshCart(null);
        rbCash.Checked = true;
        SetNote("Order #" + order.Id + " saved and sent to the kitchen.");

        using (ReceiptForm receipt = new ReceiptForm(order))
            receipt.ShowDialog(this);
    }

    private void OrderForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.F)
        {
            txtSearch.Focus();
            txtSearch.SelectAll();
            e.SuppressKeyPress = true;
        }
        else if (e.Control && e.KeyCode == Keys.Enter)
        {
            btnCheckout.PerformClick();
            e.SuppressKeyPress = true;
        }
        else if (e.KeyCode == Keys.Escape && !cmbCategory.DroppedDown)
        {
            Close();
        }
    }

    private void OrderForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (cart.Count == 0 || e.CloseReason != CloseReason.UserClosing) return;

        DialogResult answer = MessageBox.Show("Close without checking out? The current order will be discarded.",
            App.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (answer != DialogResult.Yes) e.Cancel = true;
    }

    private void SetNote(string text)
    {
        statusNote = text;
        lblNote.Text = text;
    }
}
