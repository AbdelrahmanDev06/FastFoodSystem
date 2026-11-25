namespace FastFoodPOS
{
    partial class MainForm
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.flpSide = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.btnMenuManager = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnKitchen = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslClock = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNewOrder = new System.Windows.Forms.ToolStripButton();
            this.tsbKitchen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLogout = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMenuManager = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKitchen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.flpSide.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();

            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(180, 52);
            this.lblWelcome.Size = new System.Drawing.Size(720, 430);
            this.lblWelcome.Text = "Welcome to Smash House POS\r\nChoose a screen from the left.";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWelcome.TabIndex = 0;

            this.flpSide.Controls.Add(this.btnNewOrder);
            this.flpSide.Controls.Add(this.btnMenuManager);
            this.flpSide.Controls.Add(this.btnHistory);
            this.flpSide.Controls.Add(this.btnReports);
            this.flpSide.Controls.Add(this.btnKitchen);
            this.flpSide.Name = "flpSide";
            this.flpSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpSide.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSide.WrapContents = false;
            this.flpSide.Padding = new System.Windows.Forms.Padding(12, 16, 0, 0);
            this.flpSide.Size = new System.Drawing.Size(180, 430);
            this.flpSide.TabIndex = 1;

            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Text = "New order";
            this.btnNewOrder.Size = new System.Drawing.Size(156, 44);
            this.btnNewOrder.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnNewOrder.UseVisualStyleBackColor = true;
            this.btnNewOrder.TabIndex = 0;
            this.btnNewOrder.Click += new System.EventHandler(this.NewOrder_Click);

            this.btnMenuManager.Name = "btnMenuManager";
            this.btnMenuManager.Text = "Menu manager";
            this.btnMenuManager.Size = new System.Drawing.Size(156, 44);
            this.btnMenuManager.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnMenuManager.UseVisualStyleBackColor = true;
            this.btnMenuManager.TabIndex = 1;
            this.btnMenuManager.Click += new System.EventHandler(this.MenuManager_Click);

            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Text = "Order history";
            this.btnHistory.Size = new System.Drawing.Size(156, 44);
            this.btnHistory.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.TabIndex = 2;
            this.btnHistory.Click += new System.EventHandler(this.History_Click);

            this.btnReports.Name = "btnReports";
            this.btnReports.Text = "Reports";
            this.btnReports.Size = new System.Drawing.Size(156, 44);
            this.btnReports.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.TabIndex = 3;
            this.btnReports.Click += new System.EventHandler(this.Reports_Click);

            this.btnKitchen.Name = "btnKitchen";
            this.btnKitchen.Text = "Kitchen display";
            this.btnKitchen.Size = new System.Drawing.Size(156, 44);
            this.btnKitchen.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnKitchen.UseVisualStyleBackColor = true;
            this.btnKitchen.TabIndex = 4;
            this.btnKitchen.Click += new System.EventHandler(this.Kitchen_Click);

            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.tslUser,
                this.tslClock});
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.TabIndex = 2;

            this.tslUser.Name = "tslUser";
            this.tslUser.Spring = true;
            this.tslUser.Text = "User";
            this.tslUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.tslClock.Name = "tslClock";
            this.tslClock.Text = "Clock";

            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.tsbNewOrder,
                this.tsbKitchen,
                this.toolStripSeparator1,
                this.tsbLogout});
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.TabIndex = 3;

            this.tsbNewOrder.Name = "tsbNewOrder";
            this.tsbNewOrder.Text = "New order";
            this.tsbNewOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbNewOrder.Click += new System.EventHandler(this.NewOrder_Click);

            this.tsbKitchen.Name = "tsbKitchen";
            this.tsbKitchen.Text = "Kitchen display";
            this.tsbKitchen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbKitchen.Click += new System.EventHandler(this.Kitchen_Click);

            this.toolStripSeparator1.Name = "toolStripSeparator1";

            this.tsbLogout.Name = "tsbLogout";
            this.tsbLogout.Text = "Log out";
            this.tsbLogout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbLogout.Click += new System.EventHandler(this.LogOut_Click);

            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuFile,
                this.mnuGo,
                this.mnuHelp});
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.TabIndex = 4;

            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuLogOut,
                this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Text = "&File";

            this.mnuLogOut.Name = "mnuLogOut";
            this.mnuLogOut.Text = "Log out";
            this.mnuLogOut.Click += new System.EventHandler(this.LogOut_Click);

            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.Exit_Click);

            this.mnuGo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuNewOrder,
                this.mnuMenuManager,
                this.mnuHistory,
                this.mnuReports,
                this.mnuKitchen});
            this.mnuGo.Name = "mnuGo";
            this.mnuGo.Text = "&Go to";

            this.mnuNewOrder.Name = "mnuNewOrder";
            this.mnuNewOrder.Text = "New order";
            this.mnuNewOrder.Click += new System.EventHandler(this.NewOrder_Click);

            this.mnuMenuManager.Name = "mnuMenuManager";
            this.mnuMenuManager.Text = "Menu manager";
            this.mnuMenuManager.Click += new System.EventHandler(this.MenuManager_Click);

            this.mnuHistory.Name = "mnuHistory";
            this.mnuHistory.Text = "Order history";
            this.mnuHistory.Click += new System.EventHandler(this.History_Click);

            this.mnuReports.Name = "mnuReports";
            this.mnuReports.Text = "Reports";
            this.mnuReports.Click += new System.EventHandler(this.Reports_Click);

            this.mnuKitchen.Name = "mnuKitchen";
            this.mnuKitchen.Text = "Kitchen display";
            this.mnuKitchen.Click += new System.EventHandler(this.Kitchen_Click);

            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Text = "&Help";

            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Text = "About";
            this.mnuAbout.Click += new System.EventHandler(this.About_Click);

            this.tmrClock.Enabled = true;
            this.tmrClock.Interval = 1000;
            this.tmrClock.Tick += new System.EventHandler(this.tmrClock_Tick);

            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.flpSide);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "MainForm";
            this.ClientSize = new System.Drawing.Size(900, 480);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Smash House POS";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.flpSide.ResumeLayout(false);
            this.flpSide.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.FlowLayoutPanel flpSide;
        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.Button btnMenuManager;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnKitchen;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslUser;
        private System.Windows.Forms.ToolStripStatusLabel tslClock;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNewOrder;
        private System.Windows.Forms.ToolStripButton tsbKitchen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbLogout;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuLogOut;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuGo;
        private System.Windows.Forms.ToolStripMenuItem mnuNewOrder;
        private System.Windows.Forms.ToolStripMenuItem mnuMenuManager;
        private System.Windows.Forms.ToolStripMenuItem mnuHistory;
        private System.Windows.Forms.ToolStripMenuItem mnuReports;
        private System.Windows.Forms.ToolStripMenuItem mnuKitchen;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.Timer tmrClock;
    }
}
