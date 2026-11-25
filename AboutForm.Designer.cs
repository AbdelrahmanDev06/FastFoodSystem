namespace FastFoodPOS
{
    partial class AboutForm
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
            this.components = new System.ComponentModel.Container();
            this.pnlLogo = new FastFoodPOS.DoubleBufferedPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.tmrSpin = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();

            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Size = new System.Drawing.Size(380, 170);
            this.pnlLogo.TabIndex = 3;
            this.pnlLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLogo_Paint);

            this.lblName.Name = "lblName";
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(0, 174);
            this.lblName.Size = new System.Drawing.Size(380, 30);
            this.lblName.Text = "Smash House POS";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblName.TabIndex = 0;

            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Location = new System.Drawing.Point(0, 210);
            this.lblInfo.Size = new System.Drawing.Size(380, 110);
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblInfo.Text = "Version 2.0\r\n\r\nCS 312 - Modern Development Tools\r\nC# Windows Forms\r\n\r\nControls, event handling and GDI+ graphics";
            this.lblInfo.TabIndex = 1;

            this.btnOk.Name = "btnOk";
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(145, 332);
            this.btnOk.Size = new System.Drawing.Size(90, 32);
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.TabIndex = 2;

            this.tmrSpin.Enabled = true;
            this.tmrSpin.Interval = 30;
            this.tmrSpin.Tick += new System.EventHandler(this.tmrSpin_Tick);

            this.Controls.Add(this.pnlLogo);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnOk);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "AboutForm";
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnOk;
            this.ClientSize = new System.Drawing.Size(380, 380);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.ResumeLayout(false);
        }

        #endregion

        private FastFoodPOS.DoubleBufferedPanel pnlLogo;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Timer tmrSpin;
    }
}
