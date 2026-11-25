namespace FastFoodPOS;

public partial class LoginForm : Form
{
    public LoginForm()
    {
        InitializeComponent();
        Theme.Apply(this);
    }

    private void chkShow_CheckedChanged(object sender, EventArgs e)
    {
        txtPassword.UseSystemPasswordChar = !chkShow.Checked;
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtUsername.Text.Trim() == "" || txtPassword.Text == "")
        {
            MessageBox.Show("Enter the username and the password.", "Smash House POS",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (Session.TryLogin(txtUsername.Text, txtPassword.Text))
        {
            DialogResult = DialogResult.OK;
            return;
        }

        MessageBox.Show("Wrong username or password.", "Smash House POS",
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        txtPassword.Clear();
        txtPassword.Focus();
    }
}
