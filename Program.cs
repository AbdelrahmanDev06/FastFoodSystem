namespace FastFoodPOS;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        while (true)
        {
            LoginForm login = new LoginForm();
            if (login.ShowDialog() != DialogResult.OK) break;

            MainForm main = new MainForm();
            Application.Run(main);
            if (!main.LoggedOut) break;
        }
    }
}
