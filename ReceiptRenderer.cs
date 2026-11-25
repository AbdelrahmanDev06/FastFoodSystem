using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace FastFoodPOS;

public static class ReceiptRenderer
{
    public const int PaperWidth = 300;
    private const int Margin = 16;

    public static int Measure(Order order)
    {
        using (Bitmap bmp = new Bitmap(1, 1))
        using (Graphics g = Graphics.FromImage(bmp))
            return Draw(g, order);
    }

    public static int Draw(Graphics g, Order order)
    {
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

        int w = PaperWidth;
        int y = 14;

        using (Font titleFont = new Font("Segoe UI", 16f, FontStyle.Bold))
        using (Font mono = new Font("Consolas", 9f))
        using (Font monoBold = new Font("Consolas", 9f, FontStyle.Bold))
        using (Font small = new Font("Consolas", 8f))
        using (Font totalFont = new Font("Consolas", 12f, FontStyle.Bold))
        using (Pen dashed = new Pen(Color.Gray, 1f))
        using (StringFormat centered = new StringFormat { Alignment = StringAlignment.Center })
        using (StringFormat farRight = new StringFormat { Alignment = StringAlignment.Far })
        {
            dashed.DashStyle = DashStyle.Dash;

            Gfx.DrawBurger(g, new RectangleF((w - 58) / 2f, y, 58, 46));
            y += 52;
            g.DrawString("SMASH HOUSE", titleFont, Theme.AccentBrush, new RectangleF(0, y, w, 28), centered);
            y += 30;
            g.DrawString("Fresh smashed burgers", small, Brushes.Gray, new RectangleF(0, y, w, 16), centered);
            y += 24;
            g.DrawLine(dashed, Margin, y, w - Margin, y);
            y += 10;

            g.DrawString("Order #" + order.Id, monoBold, Brushes.Black, Margin, y);
            g.DrawString(Fmt.Stamp(order.Date), mono, Brushes.Black, new RectangleF(0, y, w - Margin, 16), farRight);
            y += 18;
            g.DrawString("Payment: " + order.Payment, mono, Brushes.Black, Margin, y);
            y += 22;
            g.DrawLine(dashed, Margin, y, w - Margin, y);
            y += 10;

            int linesTop = y;
            foreach (OrderLine line in order.Lines)
            {
                g.DrawString(Cut(line.Qty + " x " + line.Item, 26), mono, Brushes.Black, Margin, y);
                g.DrawString(Fmt.Money(line.Total), mono, Brushes.Black, new RectangleF(0, y, w - Margin, 16), farRight);
                y += 17;

                if (line.Extras.Count > 0)
                {
                    g.DrawString("   + " + Cut(line.ExtrasText, 30), small, Brushes.DimGray, Margin, y);
                    y += 15;
                }
            }
            int linesBottom = y;

            y += 4;
            g.DrawLine(dashed, Margin, y, w - Margin, y);
            y += 10;

            g.DrawString("Subtotal", mono, Brushes.Black, Margin, y);
            g.DrawString(Fmt.Money(order.Subtotal), mono, Brushes.Black, new RectangleF(0, y, w - Margin, 16), farRight);
            y += 18;
            g.DrawString("Tax (" + (DataStore.TaxRate * 100m).ToString("0") + "%)", mono, Brushes.Black, Margin, y);
            g.DrawString(Fmt.Money(order.Tax), mono, Brushes.Black, new RectangleF(0, y, w - Margin, 16), farRight);
            y += 24;

            using (Pen solid = new Pen(Color.Black, 2f))
                g.DrawLine(solid, Margin, y - 4, w - Margin, y - 4);
            g.DrawString("TOTAL", totalFont, Brushes.Black, Margin, y);
            g.DrawString(Fmt.Money(order.Total), totalFont, Brushes.Black, new RectangleF(0, y, w - Margin, 22), farRight);
            y += 34;
            g.DrawLine(dashed, Margin, y, w - Margin, y);
            y += 14;

            Random pattern = new Random(order.Id);
            int bx = 60;
            while (bx < w - 60)
            {
                int barWidth = 1 + pattern.Next(3);
                if (pattern.Next(2) == 0)
                    g.FillRectangle(Brushes.Black, bx, y, barWidth, 34);
                bx += barWidth + 1;
            }
            y += 40;
            g.DrawString("Thank you - see you soon!", small, Brushes.Gray, new RectangleF(0, y, w, 16), centered);
            y += 28;

            if (order.IsVoided)
            {
                GraphicsState saved = g.Save();
                g.TranslateTransform(w / 2f, (linesTop + linesBottom) / 2f);
                g.RotateTransform(-18f);

                using (Font stampFont = new Font("Segoe UI", 34f, FontStyle.Bold))
                using (Pen stampPen = new Pen(Color.FromArgb(160, 214, 58, 38), 4f))
                using (SolidBrush stampBrush = new SolidBrush(Color.FromArgb(160, 214, 58, 38)))
                {
                    SizeF size = g.MeasureString("VOID", stampFont);
                    g.DrawRectangle(stampPen, -size.Width / 2f - 8f, -size.Height / 2f - 2f, size.Width + 16f, size.Height + 4f);
                    g.DrawString("VOID", stampFont, stampBrush, -size.Width / 2f, -size.Height / 2f);
                }

                g.Restore(saved);
            }
        }

        return y;
    }

    private static string Cut(string text, int max)
    {
        return text.Length <= max ? text : text.Substring(0, max - 3) + "...";
    }
}
