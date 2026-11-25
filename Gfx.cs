using System.Drawing.Drawing2D;

namespace FastFoodPOS;

public static class Gfx
{

    public static GraphicsPath RoundedRect(RectangleF r, float radius)
    {
        radius = Math.Min(radius, Math.Min(r.Width, r.Height) / 2f);
        GraphicsPath path = new GraphicsPath();

        if (radius <= 0.5f)
        {
            path.AddRectangle(r);
            return path;
        }

        float d = radius * 2f;
        path.AddArc(r.X, r.Y, d, d, 180, 90);
        path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
        path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
        path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
        path.CloseFigure();
        return path;
    }

    public static void FillRounded(Graphics g, Brush brush, RectangleF r, float radius)
    {
        using (GraphicsPath path = RoundedRect(r, radius))
            g.FillPath(brush, path);
    }

    public static void Tooltip(Graphics g, string text, Point mouse, Size bounds, Font font)
    {
        SizeF size = g.MeasureString(text, font);
        float w = size.Width + 16f;
        float h = size.Height + 10f;

        float x = mouse.X + 14f;
        float y = mouse.Y + 16f;
        if (x + w > bounds.Width - 4) x = mouse.X - w - 10f;
        if (y + h > bounds.Height - 4) y = mouse.Y - h - 10f;
        if (x < 4f) x = 4f;
        if (y < 4f) y = 4f;

        using (SolidBrush back = new SolidBrush(Color.FromArgb(235, 40, 38, 35)))
            FillRounded(g, back, new RectangleF(x, y, w, h), 6f);
        g.DrawString(text, font, Brushes.White, x + 8f, y + 5f);
    }

    public static void DrawBurger(Graphics g, RectangleF r)
    {
        GraphicsState saved = g.Save();
        g.SmoothingMode = SmoothingMode.AntiAlias;

        float x = r.X, y = r.Y, w = r.Width, h = r.Height;

        using (SolidBrush bun = new SolidBrush(Color.FromArgb(226, 154, 62)))
        using (SolidBrush seed = new SolidBrush(Color.FromArgb(252, 238, 205)))
        using (SolidBrush patty = new SolidBrush(Color.FromArgb(92, 54, 38)))
        using (SolidBrush cheese = new SolidBrush(Color.FromArgb(246, 192, 44)))
        using (Pen lettuce = new Pen(Color.FromArgb(104, 170, 70), Math.Max(2f, h * 0.08f)))
        {
            lettuce.StartCap = LineCap.Round;
            lettuce.EndCap = LineCap.Round;

            FillRounded(g, bun, new RectangleF(x + w * 0.05f, y + h * 0.72f, w * 0.90f, h * 0.20f), h * 0.08f);

            FillRounded(g, patty, new RectangleF(x + w * 0.02f, y + h * 0.50f, w * 0.96f, h * 0.21f), h * 0.09f);

            PointF[] melt =
            {
                new PointF(x + w * 0.06f, y + h * 0.47f),
                new PointF(x + w * 0.94f, y + h * 0.47f),
                new PointF(x + w * 0.94f, y + h * 0.54f),
                new PointF(x + w * 0.70f, y + h * 0.54f),
                new PointF(x + w * 0.62f, y + h * 0.63f),
                new PointF(x + w * 0.54f, y + h * 0.54f),
                new PointF(x + w * 0.06f, y + h * 0.54f)
            };
            g.FillPolygon(cheese, melt);

            g.FillPie(bun, x, y, w, h * 0.85f, 180, 180);

            g.FillEllipse(seed, x + w * 0.28f, y + h * 0.14f, w * 0.08f, h * 0.04f);
            g.FillEllipse(seed, x + w * 0.48f, y + h * 0.07f, w * 0.08f, h * 0.04f);
            g.FillEllipse(seed, x + w * 0.66f, y + h * 0.15f, w * 0.08f, h * 0.04f);
            g.FillEllipse(seed, x + w * 0.40f, y + h * 0.25f, w * 0.08f, h * 0.04f);
            g.FillEllipse(seed, x + w * 0.58f, y + h * 0.28f, w * 0.08f, h * 0.04f);

            PointF[] wave =
            {
                new PointF(x + w * 0.06f, y + h * 0.43f),
                new PointF(x + w * 0.22f, y + h * 0.48f),
                new PointF(x + w * 0.36f, y + h * 0.42f),
                new PointF(x + w * 0.50f, y + h * 0.48f),
                new PointF(x + w * 0.64f, y + h * 0.42f),
                new PointF(x + w * 0.78f, y + h * 0.48f),
                new PointF(x + w * 0.94f, y + h * 0.43f)
            };
            g.DrawCurve(lettuce, wave, 0.5f);
        }

        g.Restore(saved);
    }
}
