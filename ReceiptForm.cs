using System.Drawing.Imaging;

namespace FastFoodPOS;

public class ReceiptForm : Form
{
    private readonly Order order;
    private readonly int paperHeight;

    private readonly DoubleBufferedPanel pnlPaper = new DoubleBufferedPanel();
    private readonly Panel pnlButtons = new Panel();
    private readonly Button btnSaveImage = new Button();
    private readonly Button btnCloseReceipt = new Button();

    public ReceiptForm(Order order)
    {
        this.order = order;
        paperHeight = ReceiptRenderer.Measure(order);

        Text = "Receipt - order #" + order.Id;
        ClientSize = new Size(380, 620);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;

        pnlButtons.Dock = DockStyle.Bottom;
        pnlButtons.Height = 52;

        btnSaveImage.Name = "btnSaveImage";
        btnSaveImage.Text = "Save as image...";
        btnSaveImage.SetBounds(12, 10, 150, 32);
        btnSaveImage.Click += btnSaveImage_Click;

        btnCloseReceipt.Name = "btnCloseReceipt";
        btnCloseReceipt.Text = "Close";
        btnCloseReceipt.SetBounds(278, 10, 90, 32);
        btnCloseReceipt.DialogResult = DialogResult.OK;

        pnlButtons.Controls.Add(btnSaveImage);
        pnlButtons.Controls.Add(btnCloseReceipt);

        pnlPaper.Name = "pnlPaper";
        pnlPaper.Dock = DockStyle.Fill;
        pnlPaper.BackColor = Color.FromArgb(214, 212, 206);
        pnlPaper.AutoScroll = true;
        pnlPaper.AutoScrollMinSize = new Size(ReceiptRenderer.PaperWidth + 24, paperHeight + 28);
        pnlPaper.Paint += pnlPaper_Paint;

        Controls.Add(pnlPaper);
        Controls.Add(pnlButtons);

        AcceptButton = btnCloseReceipt;
        CancelButton = btnCloseReceipt;

        Theme.Apply(this);
    }

    private void pnlPaper_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        int x = Math.Max(12, (pnlPaper.ClientSize.Width - ReceiptRenderer.PaperWidth) / 2);

        g.TranslateTransform(pnlPaper.AutoScrollPosition.X + x, pnlPaper.AutoScrollPosition.Y + 14);

        using (SolidBrush shadow = new SolidBrush(Color.FromArgb(60, 0, 0, 0)))
            g.FillRectangle(shadow, 4, 4, ReceiptRenderer.PaperWidth, paperHeight);
        g.FillRectangle(Brushes.White, 0, 0, ReceiptRenderer.PaperWidth, paperHeight);

        ReceiptRenderer.Draw(g, order);
    }

    private void btnSaveImage_Click(object sender, EventArgs e)
    {
        using (SaveFileDialog dlg = new SaveFileDialog())
        {
            dlg.Filter = "PNG image (*.png)|*.png";
            dlg.FileName = "receipt_" + order.Id + ".png";
            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                using (Bitmap bmp = new Bitmap(ReceiptRenderer.PaperWidth, paperHeight))
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                    ReceiptRenderer.Draw(g, order);
                    bmp.Save(dlg.FileName, ImageFormat.Png);
                }

                MessageBox.Show("Receipt saved.", App.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save the image.\r\n" + ex.Message, App.Title,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
