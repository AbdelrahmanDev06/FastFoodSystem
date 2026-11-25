namespace FastFoodPOS;

public partial class MainForm : Form
{
    public bool LoggedOut { get; private set; }

    public MainForm()
    {
        InitializeComponent();
        Theme.Apply(this);
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        bool chef = Session.IsChef;
        bool admin = Session.IsAdmin;

        btnNewOrder.Visible = mnuNewOrder.Visible = tsbNewOrder.Visible = !chef;
        btnHistory.Visible = mnuHistory.Visible = !chef;
        btnMenuManager.Visible = mnuMenuManager.Visible = admin;
        btnReports.Visible = mnuReports.Visible = admin;
        btnKitchen.Visible = mnuKitchen.Visible = tsbKitchen.Visible = chef;

        tslUser.Text = "User: " + Session.UserName + " (" + Session.Role + ")";
        tslClock.Text = DateTime.Now.ToString("ddd d MMM, HH:mm");
    }

    private void tmrClock_Tick(object sender, EventArgs e)
    {
        tslClock.Text = DateTime.Now.ToString("ddd d MMM, HH:mm");
    }

    private void ShowScreen(Form screen)
    {
        screen.ShowDialog(this);
        screen.Dispose();
    }

    private void NewOrder_Click(object sender, EventArgs e) => ShowScreen(new OrderForm());
    private void MenuManager_Click(object sender, EventArgs e) => ShowScreen(new MenuManagerForm());
    private void History_Click(object sender, EventArgs e) => ShowScreen(new HistoryForm());
    private void Reports_Click(object sender, EventArgs e) => ShowScreen(new ReportsForm());
    private void Kitchen_Click(object sender, EventArgs e) => ShowScreen(new KitchenForm());
    private void About_Click(object sender, EventArgs e) => ShowScreen(new AboutForm());

    private void LogOut_Click(object sender, EventArgs e)
    {
        LoggedOut = true;
        Session.Clear();
        Close();
    }

    private void Exit_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void MainForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F1)
        {
            About_Click(sender, e);
            e.Handled = true;
        }
        else if (e.Control && e.KeyCode == Keys.N && btnNewOrder.Visible)
        {
            NewOrder_Click(sender, e);
            e.Handled = true;
        }
        else if (e.Control && e.KeyCode == Keys.H && btnHistory.Visible)
        {
            History_Click(sender, e);
            e.Handled = true;
        }
        else if (e.Control && e.KeyCode == Keys.R && btnReports.Visible)
        {
            Reports_Click(sender, e);
            e.Handled = true;
        }
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (LoggedOut || e.CloseReason != CloseReason.UserClosing) return;

        DialogResult answer = MessageBox.Show("Exit Smash House POS?", App.Title,
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (answer != DialogResult.Yes) e.Cancel = true;
    }
}
