namespace FastFoodPOS
{
    partial class ReportsForm
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.grpOrders = new System.Windows.Forms.GroupBox();
            this.lblOrders = new System.Windows.Forms.Label();
            this.grpRevenue = new System.Windows.Forms.GroupBox();
            this.lblRevenue = new System.Windows.Forms.Label();
            this.grpAverage = new System.Windows.Forms.GroupBox();
            this.lblAverage = new System.Windows.Forms.Label();
            this.grpItemsSold = new System.Windows.Forms.GroupBox();
            this.lblItemsSold = new System.Windows.Forms.Label();
            this.pnlBar = new FastFoodPOS.DoubleBufferedPanel();
            this.pnlPie = new FastFoodPOS.DoubleBufferedPanel();
            this.grpBest = new System.Windows.Forms.GroupBox();
            this.dgvBest = new System.Windows.Forms.DataGridView();
            this.colBestItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBestQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBestRevenue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBest)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.grpOrders.SuspendLayout();
            this.grpRevenue.SuspendLayout();
            this.grpAverage.SuspendLayout();
            this.grpItemsSold.SuspendLayout();
            this.pnlBar.SuspendLayout();
            this.pnlPie.SuspendLayout();
            this.grpBest.SuspendLayout();
            this.SuspendLayout();

            this.pnlTop.Controls.Add(this.lblFrom);
            this.pnlTop.Controls.Add(this.dtpFrom);
            this.pnlTop.Controls.Add(this.lblTo);
            this.pnlTop.Controls.Add(this.dtpTo);
            this.pnlTop.Controls.Add(this.btnGenerate);
            this.pnlTop.Controls.Add(this.btnExport);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Size = new System.Drawing.Size(980, 48);
            this.pnlTop.TabIndex = 0;

            this.lblFrom.Name = "lblFrom";
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(12, 15);
            this.lblFrom.Text = "From";
            this.lblFrom.TabIndex = 0;

            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(52, 11);
            this.dtpFrom.Size = new System.Drawing.Size(110, 23);
            this.dtpFrom.TabIndex = 1;

            this.lblTo.Name = "lblTo";
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(178, 15);
            this.lblTo.Text = "To";
            this.lblTo.TabIndex = 2;

            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(204, 11);
            this.dtpTo.Size = new System.Drawing.Size(110, 23);
            this.dtpTo.TabIndex = 3;

            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            this.btnGenerate.Location = new System.Drawing.Point(336, 9);
            this.btnGenerate.Size = new System.Drawing.Size(100, 32);
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.TabIndex = 4;

            this.btnExport.Name = "btnExport";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            this.btnExport.Location = new System.Drawing.Point(444, 9);
            this.btnExport.Size = new System.Drawing.Size(100, 32);
            this.btnExport.Text = "Export CSV";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.TabIndex = 5;

            this.pnlStats.Controls.Add(this.grpOrders);
            this.pnlStats.Controls.Add(this.grpRevenue);
            this.pnlStats.Controls.Add(this.grpAverage);
            this.pnlStats.Controls.Add(this.grpItemsSold);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Location = new System.Drawing.Point(0, 48);
            this.pnlStats.Size = new System.Drawing.Size(980, 92);
            this.pnlStats.TabIndex = 1;

            this.grpOrders.Controls.Add(this.lblOrders);
            this.grpOrders.Name = "grpOrders";
            this.grpOrders.Location = new System.Drawing.Point(12, 6);
            this.grpOrders.Size = new System.Drawing.Size(225, 78);
            this.grpOrders.Text = "Orders";
            this.grpOrders.TabIndex = 0;

            this.lblOrders.Name = "lblOrders";
            this.lblOrders.AutoSize = true;
            this.lblOrders.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrders.Location = new System.Drawing.Point(14, 28);
            this.lblOrders.Text = "86";
            this.lblOrders.TabIndex = 0;

            this.grpRevenue.Controls.Add(this.lblRevenue);
            this.grpRevenue.Name = "grpRevenue";
            this.grpRevenue.Location = new System.Drawing.Point(245, 6);
            this.grpRevenue.Size = new System.Drawing.Size(225, 78);
            this.grpRevenue.Text = "Revenue";
            this.grpRevenue.TabIndex = 1;

            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.AutoSize = true;
            this.lblRevenue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenue.Location = new System.Drawing.Point(14, 28);
            this.lblRevenue.Text = "9,842.50";
            this.lblRevenue.TabIndex = 0;

            this.grpAverage.Controls.Add(this.lblAverage);
            this.grpAverage.Name = "grpAverage";
            this.grpAverage.Location = new System.Drawing.Point(478, 6);
            this.grpAverage.Size = new System.Drawing.Size(225, 78);
            this.grpAverage.Text = "Average order";
            this.grpAverage.TabIndex = 2;

            this.lblAverage.Name = "lblAverage";
            this.lblAverage.AutoSize = true;
            this.lblAverage.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverage.Location = new System.Drawing.Point(14, 28);
            this.lblAverage.Text = "114.45";
            this.lblAverage.TabIndex = 0;

            this.grpItemsSold.Controls.Add(this.lblItemsSold);
            this.grpItemsSold.Name = "grpItemsSold";
            this.grpItemsSold.Location = new System.Drawing.Point(711, 6);
            this.grpItemsSold.Size = new System.Drawing.Size(225, 78);
            this.grpItemsSold.Text = "Items sold";
            this.grpItemsSold.TabIndex = 3;

            this.lblItemsSold.Name = "lblItemsSold";
            this.lblItemsSold.AutoSize = true;
            this.lblItemsSold.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemsSold.Location = new System.Drawing.Point(14, 28);
            this.lblItemsSold.Text = "231";
            this.lblItemsSold.TabIndex = 0;

            this.pnlBar.Name = "pnlBar";
            this.pnlBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlBar_MouseMove);
            this.pnlBar.MouseLeave += new System.EventHandler(this.pnlBar_MouseLeave);
            this.pnlBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBar.Location = new System.Drawing.Point(12, 148);
            this.pnlBar.Size = new System.Drawing.Size(540, 260);
            this.pnlBar.TabIndex = 2;
            this.pnlBar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBar_Paint);

            this.pnlPie.Name = "pnlPie";
            this.pnlPie.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlPie_MouseMove);
            this.pnlPie.MouseLeave += new System.EventHandler(this.pnlPie_MouseLeave);
            this.pnlPie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPie.Location = new System.Drawing.Point(564, 148);
            this.pnlPie.Size = new System.Drawing.Size(404, 260);
            this.pnlPie.TabIndex = 3;
            this.pnlPie.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPie_Paint);

            this.grpBest.Controls.Add(this.dgvBest);
            this.grpBest.Name = "grpBest";
            this.grpBest.Location = new System.Drawing.Point(12, 418);
            this.grpBest.Size = new System.Drawing.Size(956, 230);
            this.grpBest.Text = "Best sellers";
            this.grpBest.TabIndex = 4;

            this.dgvBest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colBestItem,
                this.colBestQty,
                this.colBestRevenue});
            this.dgvBest.Name = "dgvBest";
            this.dgvBest.AllowUserToAddRows = false;
            this.dgvBest.AllowUserToDeleteRows = false;
            this.dgvBest.ReadOnly = true;
            this.dgvBest.MultiSelect = false;
            this.dgvBest.RowHeadersVisible = false;
            this.dgvBest.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvBest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBest.TabIndex = 0;

            this.colBestItem.Name = "colBestItem";
            this.colBestItem.HeaderText = "Item";

            this.colBestQty.Name = "colBestQty";
            this.colBestQty.HeaderText = "Quantity sold";

            this.colBestRevenue.Name = "colBestRevenue";
            this.colBestRevenue.HeaderText = "Revenue";

            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlBar);
            this.Controls.Add(this.pnlPie);
            this.Controls.Add(this.grpBest);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ReportsForm";
            this.ClientSize = new System.Drawing.Size(980, 660);
            this.Text = "Reports";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.ReportsForm_Load);
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReportsForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBest)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            this.grpOrders.ResumeLayout(false);
            this.grpOrders.PerformLayout();
            this.grpRevenue.ResumeLayout(false);
            this.grpRevenue.PerformLayout();
            this.grpAverage.ResumeLayout(false);
            this.grpAverage.PerformLayout();
            this.grpItemsSold.ResumeLayout(false);
            this.grpItemsSold.PerformLayout();
            this.pnlBar.ResumeLayout(false);
            this.pnlBar.PerformLayout();
            this.pnlPie.ResumeLayout(false);
            this.pnlPie.PerformLayout();
            this.grpBest.ResumeLayout(false);
            this.grpBest.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.GroupBox grpOrders;
        private System.Windows.Forms.Label lblOrders;
        private System.Windows.Forms.GroupBox grpRevenue;
        private System.Windows.Forms.Label lblRevenue;
        private System.Windows.Forms.GroupBox grpAverage;
        private System.Windows.Forms.Label lblAverage;
        private System.Windows.Forms.GroupBox grpItemsSold;
        private System.Windows.Forms.Label lblItemsSold;
        private FastFoodPOS.DoubleBufferedPanel pnlBar;
        private FastFoodPOS.DoubleBufferedPanel pnlPie;
        private System.Windows.Forms.GroupBox grpBest;
        private System.Windows.Forms.DataGridView dgvBest;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBestItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBestQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBestRevenue;
    }
}
