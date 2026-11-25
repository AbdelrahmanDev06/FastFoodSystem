namespace FastFoodPOS
{
    partial class HistoryForm
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
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.colOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnReprint = new System.Windows.Forms.Button();
            this.btnVoid = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblSummary = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbCash = new System.Windows.Forms.RadioButton();
            this.rbCard = new System.Windows.Forms.RadioButton();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grpLines = new System.Windows.Forms.GroupBox();
            this.dgvLines = new System.Windows.Forms.DataGridView();
            this.colLineItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLineExtras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLineQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLinePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLineTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).BeginInit();
            this.pnlActions.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpLines.SuspendLayout();
            this.SuspendLayout();

            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colOrderNo,
                this.colDate,
                this.colSubtotal,
                this.colTax,
                this.colTotal,
                this.colPayment,
                this.colStatus});
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.SelectionChanged += new System.EventHandler(this.dgvOrders_SelectionChanged);
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrders.TabIndex = 0;

            this.colOrderNo.Name = "colOrderNo";
            this.colOrderNo.HeaderText = "Order #";

            this.colDate.Name = "colDate";
            this.colDate.HeaderText = "Date";

            this.colSubtotal.Name = "colSubtotal";
            this.colSubtotal.HeaderText = "Subtotal";

            this.colTax.Name = "colTax";
            this.colTax.HeaderText = "Tax";

            this.colTotal.Name = "colTotal";
            this.colTotal.HeaderText = "Total";

            this.colPayment.Name = "colPayment";
            this.colPayment.HeaderText = "Payment";

            this.colStatus.Name = "colStatus";
            this.colStatus.HeaderText = "Status";

            this.pnlActions.Controls.Add(this.btnReprint);
            this.pnlActions.Controls.Add(this.btnVoid);
            this.pnlActions.Controls.Add(this.btnDelete);
            this.pnlActions.Controls.Add(this.lblSummary);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Size = new System.Drawing.Size(980, 48);
            this.pnlActions.TabIndex = 1;

            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Click += new System.EventHandler(this.btnReprint_Click);
            this.btnReprint.Location = new System.Drawing.Point(12, 9);
            this.btnReprint.Size = new System.Drawing.Size(130, 32);
            this.btnReprint.Text = "Reprint receipt";
            this.btnReprint.UseVisualStyleBackColor = true;
            this.btnReprint.TabIndex = 0;

            this.btnVoid.Name = "btnVoid";
            this.btnVoid.Click += new System.EventHandler(this.btnVoid_Click);
            this.btnVoid.Location = new System.Drawing.Point(150, 9);
            this.btnVoid.Size = new System.Drawing.Size(120, 32);
            this.btnVoid.Text = "Void / Restore";
            this.btnVoid.UseVisualStyleBackColor = true;
            this.btnVoid.TabIndex = 1;

            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.Location = new System.Drawing.Point(278, 9);
            this.btnDelete.Size = new System.Drawing.Size(120, 32);
            this.btnDelete.Text = "Delete order";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.TabIndex = 2;

            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSummary.Size = new System.Drawing.Size(380, 48);
            this.lblSummary.Text = "5 paid orders   |   Revenue 707.94";
            this.lblSummary.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSummary.TabIndex = 3;

            this.pnlFilter.Controls.Add(this.lblFrom);
            this.pnlFilter.Controls.Add(this.dtpFrom);
            this.pnlFilter.Controls.Add(this.lblTo);
            this.pnlFilter.Controls.Add(this.dtpTo);
            this.pnlFilter.Controls.Add(this.rbAll);
            this.pnlFilter.Controls.Add(this.rbCash);
            this.pnlFilter.Controls.Add(this.rbCard);
            this.pnlFilter.Controls.Add(this.txtOrderId);
            this.pnlFilter.Controls.Add(this.btnSearch);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Size = new System.Drawing.Size(980, 48);
            this.pnlFilter.TabIndex = 2;

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

            this.rbAll.Name = "rbAll";
            this.rbAll.CheckedChanged += new System.EventHandler(this.Payment_CheckedChanged);
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(340, 13);
            this.rbAll.TabStop = true;
            this.rbAll.Text = "All";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.TabIndex = 4;

            this.rbCash.Name = "rbCash";
            this.rbCash.CheckedChanged += new System.EventHandler(this.Payment_CheckedChanged);
            this.rbCash.AutoSize = true;
            this.rbCash.Location = new System.Drawing.Point(392, 13);
            this.rbCash.Text = "Cash";
            this.rbCash.UseVisualStyleBackColor = true;
            this.rbCash.TabIndex = 5;

            this.rbCard.Name = "rbCard";
            this.rbCard.CheckedChanged += new System.EventHandler(this.Payment_CheckedChanged);
            this.rbCard.AutoSize = true;
            this.rbCard.Location = new System.Drawing.Point(452, 13);
            this.rbCard.Text = "Card";
            this.rbCard.UseVisualStyleBackColor = true;
            this.rbCard.TabIndex = 6;

            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOrderId_KeyPress);
            this.txtOrderId.Location = new System.Drawing.Point(520, 11);
            this.txtOrderId.PlaceholderText = "Order #";
            this.txtOrderId.Size = new System.Drawing.Size(90, 23);
            this.txtOrderId.TabIndex = 7;

            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.Location = new System.Drawing.Point(624, 9);
            this.btnSearch.Size = new System.Drawing.Size(90, 32);
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.TabIndex = 8;

            this.grpLines.Controls.Add(this.dgvLines);
            this.grpLines.Name = "grpLines";
            this.grpLines.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpLines.Size = new System.Drawing.Size(980, 200);
            this.grpLines.Text = "Items in the selected order";
            this.grpLines.TabIndex = 3;

            this.dgvLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colLineItem,
                this.colLineExtras,
                this.colLineQty,
                this.colLinePrice,
                this.colLineTotal});
            this.dgvLines.Name = "dgvLines";
            this.dgvLines.AllowUserToAddRows = false;
            this.dgvLines.AllowUserToDeleteRows = false;
            this.dgvLines.ReadOnly = true;
            this.dgvLines.MultiSelect = false;
            this.dgvLines.RowHeadersVisible = false;
            this.dgvLines.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLines.TabIndex = 0;

            this.colLineItem.Name = "colLineItem";
            this.colLineItem.HeaderText = "Item";

            this.colLineExtras.Name = "colLineExtras";
            this.colLineExtras.HeaderText = "Extras";

            this.colLineQty.Name = "colLineQty";
            this.colLineQty.HeaderText = "Qty";

            this.colLinePrice.Name = "colLinePrice";
            this.colLinePrice.HeaderText = "Price";

            this.colLineTotal.Name = "colLineTotal";
            this.colLineTotal.HeaderText = "Total";

            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.grpLines);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "HistoryForm";
            this.ClientSize = new System.Drawing.Size(980, 620);
            this.Text = "Order history";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.HistoryForm_Load);
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HistoryForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).EndInit();
            this.pnlActions.ResumeLayout(false);
            this.pnlActions.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.grpLines.ResumeLayout(false);
            this.grpLines.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnReprint;
        private System.Windows.Forms.Button btnVoid;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbCash;
        private System.Windows.Forms.RadioButton rbCard;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox grpLines;
        private System.Windows.Forms.DataGridView dgvLines;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineExtras;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLinePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineTotal;
    }
}
