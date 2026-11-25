using System.Drawing.Drawing2D;

namespace FastFoodPOS;

public partial class AboutForm : Form
{
    private float angle;

    public AboutForm()
    {
        InitializeComponent();
        Theme.Apply(this);
    }

    private void tmrSpin_Tick(object sender, EventArgs e)
    {
        angle = (angle + 1.5f) % 360f;
        pnlLogo.Invalidate();
    }

    private void pnlLogo_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        float cx = pnlLogo.Width / 2f;
        float cy = pnlLogo.Height / 2f;
        float bob = (float)Math.Sin(angle * Math.PI / 90.0) * 3f;

        g.TranslateTransform(cx, cy);
        g.RotateTransform(angle);

        using (Pen ring = new Pen(Theme.AccentColor, 3f))
        {
            ring.DashStyle = DashStyle.Dash;
            g.DrawEllipse(ring, -62f, -62f, 124f, 124f);
        }

        using (SolidBrush dot = new SolidBrush(Theme.Gold))
        {
            for (int i = 0; i < 12; i++)
            {
                g.RotateTransform(30f);
                g.FillEllipse(dot, -3f, -75f, 6f, 6f);
            }
        }
        g.ResetTransform();

        Gfx.DrawBurger(g, new RectangleF(cx - 38f, cy - 31f + bob, 76f, 62f));
    }
}
