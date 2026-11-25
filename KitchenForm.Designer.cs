namespace FastFoodPOS
{
    partial class KitchenForm
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
            this.flpBoard = new System.Windows.Forms.FlowLayoutPanel();
            this.lblEmpty = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnRestore = new System.Windows.Forms.Button();
            this.flpBoard.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();

            this.flpBoard.Name = "flpBoard";
            this.flpBoard.AutoScroll = true;
            this.flpBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBoard.Padding = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.flpBoard.Size = new System.Drawing.Size(960, 514);
            this.flpBoard.TabIndex = 0;

            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmpty.Size = new System.Drawing.Size(960, 514);
            this.lblEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEmpty.Visible = false;
            this.lblEmpty.Text = "No open tickets.\r\nNew orders from the POS show up here.";
            this.lblEmpty.TabIndex = 1;

            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.btnRestore);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Size = new System.Drawing.Size(960, 46);
            this.pnlTop.TabIndex = 2;

            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Size = new System.Drawing.Size(770, 46);
            this.lblTitle.Text = "Kitchen display";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.TabIndex = 0;

            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRestore.Size = new System.Drawing.Size(190, 46);
            this.btnRestore.Text = "Restore sample tickets";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.TabIndex = 1;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);

            this.Controls.Add(this.flpBoard);
            this.Controls.Add(this.lblEmpty);
            this.Controls.Add(this.pnlTop);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "KitchenForm";
            this.ClientSize = new System.Drawing.Size(960, 560);
            this.Text = "Kitchen display";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.KitchenForm_Load);
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KitchenForm_KeyDown);
            this.flpBoard.ResumeLayout(false);
            this.flpBoard.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpBoard;
        private System.Windows.Forms.Label lblEmpty;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnRestore;
    }
}
