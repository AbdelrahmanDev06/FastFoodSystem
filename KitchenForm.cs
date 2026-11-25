using System.Drawing.Drawing2D;

namespace FastFoodPOS;

public partial class KitchenForm : Form
{
    private const int TargetMinutes = 15;

    private class TicketCard
    {
        public KitchenTicket Ticket;
        public Panel Card;
        public Label Head;
        public DoubleBufferedPanel Bar;
    }

    private readonly List<TicketCard> cards = new List<TicketCard>();
    private readonly System.Windows.Forms.Timer tmrAge = new System.Windows.Forms.Timer();

    public KitchenForm()
    {
        InitializeComponent();
        Theme.Apply(this);

        tmrAge.Interval = 10000;
        tmrAge.Tick += tmrAge_Tick;
    }

    private void KitchenForm_Load(object sender, EventArgs e)
    {
        BuildBoard();
        tmrAge.Start();
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        tmrAge.Stop();
        tmrAge.Dispose();
        base.OnFormClosed(e);
    }

    private void KitchenForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape) Close();
    }

    private void btnRestore_Click(object sender, EventArgs e)
    {
        DataStore.RestoreSampleTickets();
        BuildBoard();
    }

    private void BuildBoard()
    {
        cards.Clear();
        while (flpBoard.Controls.Count > 0)
            flpBoard.Controls[0].Dispose();

        foreach (KitchenTicket ticket in DataStore.Tickets.OrderBy(t => t.Created))
            AddTicket(ticket);

        UpdateState();
    }

    private void AddTicket(KitchenTicket ticket)
    {
        Panel card = new Panel();
        card.Size = new Size(280, 230);
        card.Margin = new Padding(8);
        card.BorderStyle = BorderStyle.FixedSingle;

        Label head = new Label();
        head.Dock = DockStyle.Top;
        head.Height = 38;
        head.Font = new Font(Font, FontStyle.Bold);
        head.TextAlign = ContentAlignment.MiddleLeft;

        DoubleBufferedPanel bar = new DoubleBufferedPanel();
        bar.Dock = DockStyle.Top;
        bar.Height = 8;
        bar.BackColor = Color.Gainsboro;
        bar.Tag = ticket;
        bar.Paint += AgeBar_Paint;

        Label body = new Label();
        body.Text = ticket.Lines;
        body.Dock = DockStyle.Fill;
        body.Padding = new Padding(8);

        Button done = new Button();
        done.Text = "Done";
        done.Dock = DockStyle.Bottom;
        done.Height = 40;
        Theme.StylePrimary(done);
        done.Click += Done_Click;

        card.Controls.Add(body);
        card.Controls.Add(done);
        card.Controls.Add(bar);
        card.Controls.Add(head);
        flpBoard.Controls.Add(card);

        TicketCard tc = new TicketCard { Ticket = ticket, Card = card, Head = head, Bar = bar };
        cards.Add(tc);
        UpdateHead(tc);
    }

    private static Color ColorForAge(int minutes)
    {
        if (minutes < 5) return Color.Gainsboro;
        if (minutes < 12) return Color.Gold;
        return Color.Tomato;
    }

    private static string AgeText(int minutes)
    {
        return minutes < 1 ? "just now" : minutes + " min";
    }

    private void UpdateHead(TicketCard tc)
    {
        int minutes = tc.Ticket.AgeMinutes;
        tc.Head.Text = "Order #" + tc.Ticket.OrderNo + "   -   " + AgeText(minutes);
        tc.Head.BackColor = ColorForAge(minutes);
        tc.Bar.Invalidate();
    }

    private void tmrAge_Tick(object sender, EventArgs e)
    {
        foreach (TicketCard tc in cards)
            UpdateHead(tc);
    }

    private void AgeBar_Paint(object sender, PaintEventArgs e)
    {
        DoubleBufferedPanel bar = (DoubleBufferedPanel)sender;
        KitchenTicket ticket = (KitchenTicket)bar.Tag;

        Rectangle full = bar.ClientRectangle;
        if (full.Width < 2 || full.Height < 2) return;

        double minutes = Math.Max(0.0, (DateTime.Now - ticket.Created).TotalMinutes);
        double fraction = Math.Min(1.0, minutes / TargetMinutes);
        int fillWidth = (int)(full.Width * fraction);
        if (fillWidth < 1) return;

        using (LinearGradientBrush brush = new LinearGradientBrush(full, Theme.Green, Theme.AccentColor, LinearGradientMode.Horizontal))
        {
            ColorBlend blend = new ColorBlend(3);
            blend.Colors = new Color[] { Theme.Green, Theme.Gold, Theme.AccentColor };
            blend.Positions = new float[] { 0f, 0.5f, 1f };
            brush.InterpolationColors = blend;
            e.Graphics.FillRectangle(brush, 0, 0, fillWidth, full.Height);
        }
    }

    private void Done_Click(object sender, EventArgs e)
    {
        Control card = ((Button)sender).Parent;
        TicketCard tc = cards.First(c => c.Card == card);

        DataStore.CompleteTicket(tc.Ticket);
        cards.Remove(tc);
        flpBoard.Controls.Remove(card);
        card.Dispose();
        UpdateState();
    }

    private void UpdateState()
    {
        int n = flpBoard.Controls.Count;
        lblTitle.Text = n == 1 ? "Kitchen display  -  1 open ticket" : "Kitchen display  -  " + n + " open tickets";
        flpBoard.Visible = n > 0;
        lblEmpty.Visible = n == 0;
    }
}
