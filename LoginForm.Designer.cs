namespace FastFoodPOS
{
    partial class LoginForm
    {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkShow = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblTitle.Name = "lblTitle";
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(24, 16);
            this.lblTitle.Text = "Smash House";
            this.lblTitle.TabIndex = 0;

            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Location = new System.Drawing.Point(26, 56);
            this.lblSubtitle.Text = "Log in to start taking orders";
            this.lblSubtitle.TabIndex = 1;

            this.lblUsername.Name = "lblUsername";
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(26, 92);
            this.lblUsername.Text = "Username";
            this.lblUsername.TabIndex = 2;

            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Location = new System.Drawing.Point(26, 112);
            this.txtUsername.MaxLength = 30;
            this.txtUsername.Size = new System.Drawing.Size(308, 23);
            this.txtUsername.TabIndex = 3;

            this.lblPassword.Name = "lblPassword";
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(26, 148);
            this.lblPassword.Text = "Password";
            this.lblPassword.TabIndex = 4;

            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Location = new System.Drawing.Point(26, 168);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.Size = new System.Drawing.Size(308, 23);
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.TabIndex = 5;

            this.chkShow.Name = "chkShow";
            this.chkShow.AutoSize = true;
            this.chkShow.Location = new System.Drawing.Point(26, 200);
            this.chkShow.Text = "Show password";
            this.chkShow.UseVisualStyleBackColor = true;
            this.chkShow.TabIndex = 6;
            this.chkShow.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);

            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Location = new System.Drawing.Point(150, 240);
            this.btnLogin.Size = new System.Drawing.Size(90, 32);
            this.btnLogin.Text = "Log in";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Location = new System.Drawing.Point(246, 240);
            this.btnCancel.Size = new System.Drawing.Size(88, 32);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.TabIndex = 8;

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.chkShow);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnCancel);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "LoginForm";
            this.AcceptButton = this.btnLogin;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(360, 292);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Smash House POS - Log in";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkShow;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCancel;
    }
}
