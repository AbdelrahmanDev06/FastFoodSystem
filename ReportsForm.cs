using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Text;

namespace FastFoodPOS;

public partial class ReportsForm : Form
{

    private class DayBar { public DateTime Day; public decimal Total; }
    private class Slice  { public string Name = ""; public decimal Value; }

    private List<DayBar> days = new List<DayBar>();
    private List<Slice> slices = new List<Slice>();
    private List<Order> rangeOrders = new List<Order>();
    private DateTime rangeFrom, rangeTo;
    private bool trimmedRange;

    private readonly List<RectangleF> columns = new List<RectangleF>();
    private RectangleF pieArea = RectangleF.Empty;
    private int hoverBar = -1, hoverSlice = -1;
    private Point mouseBar, mousePie;
    private float progress = 1f;
    private readonly System.Windows.Forms.Timer tmrAnim = new System.Windows.Forms.Timer();

    private ContextMenuStrip menuBar, menuPie;

    public ReportsForm()
    {
        InitializeComponent();
        Theme.Apply(this);

        tmrAnim.Interval = 20;
        tmrAnim.Tick += tmrAnim_Tick;

        menuBar = BuildChartMenu(pnlBar);
        menuPie = BuildChartMenu(pnlPie);
        pnlBar.ContextMenuStrip = menuBar;
        pnlPie.ContextMenuStrip = menuPie;
    }

    private void ReportsForm_Load(object sender, EventArgs e)
    {
        dtpFrom.Value = DateTime.Today.AddDays(-13);
        dtpTo.Value = DateTime.Today;
        Generate(true);
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        tmrAnim.Stop();
        tmrAnim.Dispose();
        menuBar.Dispose();
        menuPie.Dispose();
        base.OnFormClosed(e);
    }

    private void ReportsForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F5) btnGenerate.PerformClick();
        else if (e.KeyCode == Keys.Escape) Close();
    }

    private void btnGenerate_Click(object sender, EventArgs e)
    {
        Generate(true);
    }

    private bool Generate(bool animate)
    {
        DateTime from = dtpFrom.Value.Date;
        DateTime to = dtpTo.Value.Date;
        if (from > to)
        {
            MessageBox.Show("The start date must not be after the end date.", App.Title,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dtpFrom.Focus();
            return false;
        }

        rangeFrom = from;
        rangeTo = to;
        DateTime end = to.AddDays(1);
        rangeOrders = DataStore.Orders.Where(o => !o.IsVoided && o.Date >= from && o.Date < end).ToList();

        int orderCount = rangeOrders.Count;
        decimal revenue = rangeOrders.Sum(o => o.Total);
        int itemsSold = rangeOrders.Sum(o => o.Lines.Sum(l => l.Qty));
        lblOrders.Text = Fmt.Int(orderCount);
        lblRevenue.Text = Fmt.Money(revenue);
        lblAverage.Text = orderCount == 0 ? "0.00" : Fmt.Money(revenue / orderCount);
        lblItemsSold.Text = Fmt.Int(itemsSold);

        DateTime chartFrom = from;
        trimmedRange = (to - from).Days > 30;
        if (trimmedRange) chartFrom = to.AddDays(-30);

        days = new List<DayBar>();
        for (DateTime d = chartFrom; d <= to; d = d.AddDays(1))
        {
            DateTime day = d;
            days.Add(new DayBar { Day = day, Total = rangeOrders.Where(o => o.Date.Date == day).Sum(o => o.Total) });
        }

        decimal factor = 1m + DataStore.TaxRate;
        slices = rangeOrders.SelectMany(o => o.Lines)
            .GroupBy(l => l.Category)
            .Select(gp => new Slice { Name = gp.Key, Value = gp.Sum(l => l.Total) * factor })
            .OrderBy(s => { int i = DataStore.Categories.IndexOf(s.Name); return i < 0 ? 999 : i; })
            .ToList();

        var best = rangeOrders.SelectMany(o => o.Lines)
            .GroupBy(l => l.Item)
            .Select(gp => new { Name = gp.Key, Qty = gp.Sum(l => l.Qty), Revenue = gp.Sum(l => l.Total) })
            .OrderByDescending(x => x.Qty)
            .ThenBy(x => x.Name)
            .Take(5);

        dgvBest.Rows.Clear();
        foreach (var x in best)
            dgvBest.Rows.Add(x.Name, Fmt.Int(x.Qty), Fmt.Money(x.Revenue));

        hoverBar = -1;
        hoverSlice = -1;
        if (animate)
        {
            progress = 0f;
            tmrAnim.Start();
        }
        else
        {
            progress = 1f;
        }
        pnlBar.Invalidate();
        pnlPie.Invalidate();
        return true;
    }

    private void tmrAnim_Tick(object sender, EventArgs e)
    {
        progress += 0.04f;
        if (progress >= 1f)
        {
            progress = 1f;
            tmrAnim.Stop();
        }
        pnlBar.Invalidate();
        pnlPie.Invalidate();
    }

    private float Eased()
    {
        return 1f - (float)Math.Pow(1f - progress, 3);
    }

    private void pnlBar_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        columns.Clear();

        string title = trimmedRange ? "Daily sales (last 31 days of the range)" : "Daily sales";
        using (Font titleFont = new Font(Font, FontStyle.Bold))
            g.DrawString(title, titleFont, Brushes.Black, 10, 8);

        if (days.Count == 0 || days.All(d => d.Total == 0m))
        {
            DrawEmpty(g, pnlBar.ClientSize);
            return;
        }

        const int left = 48, right = 14, top = 40, bottomPad = 30;
        Rectangle plot = new Rectangle(left, top, pnlBar.ClientSize.Width - left - right, pnlBar.ClientSize.Height - top - bottomPad);
        if (plot.Width < 20 || plot.Height < 20) return;

        decimal peak = days.Max(d => d.Total);
        decimal scaleMax = NiceMax(peak);
        const int gridLines = 4;

        using (Pen gridPen = new Pen(Theme.Line))
        using (Font small = new Font("Segoe UI", 7f))
        using (StringFormat farRight = new StringFormat { Alignment = StringAlignment.Far })
        using (StringFormat centered = new StringFormat { Alignment = StringAlignment.Center })
        {

            for (int i = 0; i <= gridLines; i++)
            {
                float gy = plot.Bottom - plot.Height * i / (float)gridLines;
                g.DrawLine(gridPen, plot.Left, gy, plot.Right, gy);
                decimal value = scaleMax * i / gridLines;
                g.DrawString(value.ToString("0.##", CultureInfo.InvariantCulture), small, Brushes.Gray,
                             new RectangleF(0, gy - 7, left - 5, 14), farRight);
            }

            int n = days.Count;
            float slot = plot.Width / (float)n;
            float barWidth = Math.Max(3f, slot * 0.68f);
            float ease = Eased();
            int labelStep = Math.Max(1, (int)Math.Ceiling(34f / slot));

            for (int i = 0; i < n; i++)
            {
                columns.Add(new RectangleF(plot.Left + i * slot, plot.Top, slot, plot.Height + 24));

                float h = (float)(days[i].Total / scaleMax) * plot.Height * ease;
                float x = plot.Left + i * slot + (slot - barWidth) / 2f;
                RectangleF bar = new RectangleF(x, plot.Bottom - h, barWidth, h);

                if (h >= 1f)
                {
                    Color baseColor = days[i].Total == peak ? Theme.AccentColor : Theme.BarColor;
                    if (i == hoverBar) baseColor = ControlPaint.Dark(baseColor);

                    using (LinearGradientBrush brush = new LinearGradientBrush(bar, ControlPaint.Light(baseColor), baseColor, LinearGradientMode.Vertical))
                        g.FillRectangle(brush, bar);
                }

                if (i % labelStep == 0)
                    g.DrawString(Fmt.DayMonth(days[i].Day), small, Brushes.Black,
                                 new RectangleF(plot.Left + i * slot - 8, plot.Bottom + 5, slot + 16, 14), centered);

                if (ease >= 1f && days[i].Total == peak)
                    g.DrawString(Fmt.Whole(days[i].Total), small, Brushes.Black,
                                 new RectangleF(x - 20, bar.Top - 14, barWidth + 40, 14), centered);
            }
        }

        if (hoverBar >= 0 && hoverBar < days.Count)
        {
            string text = days[hoverBar].Day.ToString("ddd dd/MM", CultureInfo.InvariantCulture) + "\n" + Fmt.Money(days[hoverBar].Total);
            Gfx.Tooltip(g, text, mouseBar, pnlBar.ClientSize, Font);
        }
    }

    private static decimal NiceMax(decimal max)
    {
        if (max <= 0m) return 4m;

        double scale = Math.Pow(10, Math.Floor(Math.Log10((double)max)));
        double fraction = (double)max / scale;
        foreach (double step in new double[] { 1, 2, 4, 6, 8, 10 })
            if (fraction <= step + 1e-9) return (decimal)(step * scale);
        return (decimal)(10 * scale);
    }

    private void DrawEmpty(Graphics g, Size area)
    {
        using (StringFormat centered = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            g.DrawString("No sales in this period", Font, Brushes.Gray, new RectangleF(0, 0, area.Width, area.Height), centered);
    }

    private void pnlBar_MouseMove(object sender, MouseEventArgs e)
    {
        int hit = -1;
        for (int i = 0; i < columns.Count; i++)
            if (columns[i].Contains(e.Location)) hit = i;

        if (hit != hoverBar || hit >= 0)
        {
            hoverBar = hit;
            mouseBar = e.Location;
            pnlBar.Cursor = hit >= 0 ? Cursors.Hand : Cursors.Default;
            pnlBar.Invalidate();
        }
    }

    private void pnlBar_MouseLeave(object sender, EventArgs e)
    {
        hoverBar = -1;
        pnlBar.Invalidate();
    }

    private void pnlPie_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        using (Font titleFont = new Font(Font, FontStyle.Bold))
            g.DrawString("Revenue by category", titleFont, Brushes.Black, 10, 8);

        decimal total = slices.Sum(s => s.Value);
        if (total <= 0m)
        {
            pieArea = RectangleF.Empty;
            DrawEmpty(g, pnlPie.ClientSize);
            return;
        }

        int diameter = Math.Min(pnlPie.ClientSize.Height - 64, pnlPie.ClientSize.Width / 2 - 10);
        if (diameter < 40) return;
        pieArea = new RectangleF(18, 46, diameter, diameter);

        float ease = Eased();
        float start = -90f;
        float cx = pieArea.X + pieArea.Width / 2f;
        float cy = pieArea.Y + pieArea.Height / 2f;

        using (Font percentFont = new Font("Segoe UI", 8f, FontStyle.Bold))
        using (Font nameFont = new Font(Font, FontStyle.Bold))
        using (Font small = new Font("Segoe UI", 8f))
        using (Pen edge = new Pen(Color.White, 2f))
        using (StringFormat centered = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
        {
            for (int i = 0; i < slices.Count; i++)
            {
                float fullSweep = (float)(slices[i].Value / total) * 360f;
                float sweep = fullSweep * ease;
                double middle = (start + sweep / 2f) * Math.PI / 180.0;

                using (SolidBrush brush = new SolidBrush(Theme.CategoryColor(slices[i].Name)))
                {
                    GraphicsState saved = g.Save();
                    if (i == hoverSlice)
                        g.TranslateTransform((float)Math.Cos(middle) * 8f, (float)Math.Sin(middle) * 8f);

                    if (sweep > 0.1f)
                    {
                        g.FillPie(brush, pieArea.X, pieArea.Y, pieArea.Width, pieArea.Height, start, sweep);
                        if (fullSweep < 359.9f)
                            g.DrawPie(edge, pieArea, start, sweep);
                    }

                    if (ease >= 1f && fullSweep >= 24f)
                    {
                        float lx = cx + (float)Math.Cos(middle) * pieArea.Width * 0.32f;
                        float ly = cy + (float)Math.Sin(middle) * pieArea.Height * 0.32f;
                        string percent = (slices[i].Value / total * 100m).ToString("0", CultureInfo.InvariantCulture) + "%";
                        g.DrawString(percent, percentFont, Brushes.White, new RectangleF(lx - 24, ly - 8, 48, 16), centered);
                    }
                    g.Restore(saved);
                }
                start += sweep;

                float rowY = 56 + i * 46;
                float legendX = pieArea.Right + 24;
                if (i == hoverSlice)
                    using (SolidBrush highlight = new SolidBrush(Theme.Selection))
                        Gfx.FillRounded(g, highlight, new RectangleF(legendX - 8, rowY - 6, pnlPie.ClientSize.Width - legendX - 2, 42), 6f);

                using (SolidBrush swatch = new SolidBrush(Theme.CategoryColor(slices[i].Name)))
                    g.FillRectangle(swatch, legendX, rowY + 2, 14, 14);
                g.DrawString(slices[i].Name, nameFont, Brushes.Black, legendX + 22, rowY);
                g.DrawString(Fmt.Money(slices[i].Value) + "  (" + (slices[i].Value / total * 100m).ToString("0.#", CultureInfo.InvariantCulture) + "%)",
                             small, Brushes.DimGray, legendX + 22, rowY + 18);
            }
        }

        if (hoverSlice >= 0 && hoverSlice < slices.Count)
        {
            string text = slices[hoverSlice].Name + "\n" + Fmt.Money(slices[hoverSlice].Value);
            Gfx.Tooltip(g, text, mousePie, pnlPie.ClientSize, Font);
        }
    }

    private int HitSlice(Point p)
    {
        if (progress < 1f || pieArea.IsEmpty) return -1;
        decimal total = slices.Sum(s => s.Value);
        if (total <= 0m) return -1;

        float dx = p.X - (pieArea.X + pieArea.Width / 2f);
        float dy = p.Y - (pieArea.Y + pieArea.Height / 2f);
        if (Math.Sqrt(dx * dx + dy * dy) > pieArea.Width / 2f) return -1;

        double angle = Math.Atan2(dy, dx) * 180.0 / Math.PI;
        angle = (angle + 90.0 + 360.0) % 360.0;

        float sum = 0f;
        for (int i = 0; i < slices.Count; i++)
        {
            sum += (float)(slices[i].Value / total) * 360f;
            if (angle < sum) return i;
        }
        return slices.Count - 1;
    }

    private void pnlPie_MouseMove(object sender, MouseEventArgs e)
    {
        int hit = HitSlice(e.Location);
        if (hit != hoverSlice || hit >= 0)
        {
            hoverSlice = hit;
            mousePie = e.Location;
            pnlPie.Cursor = hit >= 0 ? Cursors.Hand : Cursors.Default;
            pnlPie.Invalidate();
        }
    }

    private void pnlPie_MouseLeave(object sender, EventArgs e)
    {
        hoverSlice = -1;
        pnlPie.Invalidate();
    }

    private ContextMenuStrip BuildChartMenu(Control chart)
    {
        ContextMenuStrip menu = new ContextMenuStrip();
        ToolStripMenuItem save = new ToolStripMenuItem("Save chart as PNG...");
        save.Click += (s, args) => SaveChartImage(chart);
        menu.Items.Add(save);
        return menu;
    }

    private void SaveChartImage(Control chart)
    {
        hoverBar = -1;
        hoverSlice = -1;

        using (SaveFileDialog dlg = new SaveFileDialog())
        {
            dlg.Filter = "PNG image (*.png)|*.png";
            dlg.FileName = chart == pnlBar ? "daily_sales.png" : "revenue_by_category.png";
            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                using (Bitmap bmp = new Bitmap(chart.Width, chart.Height))
                {
                    chart.DrawToBitmap(bmp, new Rectangle(0, 0, chart.Width, chart.Height));
                    bmp.Save(dlg.FileName, ImageFormat.Png);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save the image.\r\n" + ex.Message, App.Title,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private static string Csv(string text)
    {
        if (text.Contains(',') || text.Contains('"'))
            return "\"" + text.Replace("\"", "\"\"") + "\"";
        return text;
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
        if (!Generate(false)) return;

        using (SaveFileDialog dlg = new SaveFileDialog())
        {
            dlg.Filter = "CSV file (*.csv)|*.csv";
            dlg.FileName = "sales_" + rangeFrom.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                         + "_" + rangeTo.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + ".csv";
            if (dlg.ShowDialog(this) != DialogResult.OK) return;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Smash House POS - sales report");
            sb.AppendLine("From," + rangeFrom.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            sb.AppendLine("To," + rangeTo.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            sb.AppendLine();

            sb.AppendLine("Date,Orders,Revenue");
            for (DateTime d = rangeFrom; d <= rangeTo; d = d.AddDays(1))
            {
                DateTime day = d;
                List<Order> ofDay = rangeOrders.Where(o => o.Date.Date == day).ToList();
                sb.AppendLine(day.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "," + ofDay.Count + "," + ofDay.Sum(o => o.Total).ToString("0.00", CultureInfo.InvariantCulture));
            }

            sb.AppendLine();
            sb.AppendLine("Item,Quantity,Revenue");
            foreach (var x in rangeOrders.SelectMany(o => o.Lines).GroupBy(l => l.Item)
                         .Select(gp => new { Name = gp.Key, Qty = gp.Sum(l => l.Qty), Revenue = gp.Sum(l => l.Total) })
                         .OrderByDescending(q => q.Qty))
                sb.AppendLine(Csv(x.Name) + "," + x.Qty + "," + x.Revenue.ToString("0.00", CultureInfo.InvariantCulture));

            sb.AppendLine();
            sb.AppendLine("Category,Revenue");
            foreach (Slice s in slices)
                sb.AppendLine(Csv(s.Name) + "," + s.Value.ToString("0.00", CultureInfo.InvariantCulture));

            try
            {
                File.WriteAllText(dlg.FileName, sb.ToString(), new UTF8Encoding(true));
                MessageBox.Show("Report exported.", App.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not write the file.\r\n" + ex.Message, App.Title,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
