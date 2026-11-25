namespace FastFoodPOS
{
    partial class OrderForm
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
            this.flpMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.grpExtras = new System.Windows.Forms.GroupBox();
            this.flpExtras = new System.Windows.Forms.FlowLayoutPanel();
            this.lblQty = new System.Windows.Forms.Label();
            this.numQty = new System.Windows.Forms.NumericUpDown();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.grpCart = new System.Windows.Forms.GroupBox();
            this.btnExtras = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.colItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExtras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSubtotalCap = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblTaxCap = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblTotalCap = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.grpPay = new System.Windows.Forms.GroupBox();
            this.rbCash = new System.Windows.Forms.RadioButton();
            this.rbCard = new System.Windows.Forms.RadioButton();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.lblNote = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.flpMenu.SuspendLayout();
            this.grpExtras.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpCart.SuspendLayout();
            this.grpPay.SuspendLayout();
            this.SuspendLayout();

            this.flpMenu.Name = "flpMenu";
            this.flpMenu.AutoScroll = true;
            this.flpMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMenu.Location = new System.Drawing.Point(0, 44);
            this.flpMenu.Size = new System.Drawing.Size(600, 476);
            this.flpMenu.TabIndex = 0;

            this.grpExtras.Controls.Add(this.flpExtras);
            this.grpExtras.Controls.Add(this.lblQty);
            this.grpExtras.Controls.Add(this.numQty);
            this.grpExtras.Name = "grpExtras";
            this.grpExtras.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpExtras.Location = new System.Drawing.Point(0, 520);
            this.grpExtras.Size = new System.Drawing.Size(600, 100);
            this.grpExtras.Text = "Extras for the selected line";
            this.grpExtras.TabIndex = 1;

            this.flpExtras.Name = "flpExtras";
            this.flpExtras.AutoScroll = true;
            this.flpExtras.Location = new System.Drawing.Point(12, 24);
            this.flpExtras.Size = new System.Drawing.Size(420, 68);
            this.flpExtras.TabIndex = 0;

            this.lblQty.Name = "lblQty";
            this.lblQty.AutoSize = true;
            this.lblQty.Location = new System.Drawing.Point(450, 28);
            this.lblQty.Text = "Quantity";
            this.lblQty.TabIndex = 4;

            this.numQty.Name = "numQty";
            this.numQty.ValueChanged += new System.EventHandler(this.numQty_ValueChanged);
            this.numQty.Location = new System.Drawing.Point(450, 52);
            this.numQty.Size = new System.Drawing.Size(70, 23);
            this.numQty.Maximum = new decimal(new int[] {99, 0, 0, 0});
            this.numQty.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.numQty.Value = new decimal(new int[] {1, 0, 0, 0});
            this.numQty.TabIndex = 5;

            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.cmbCategory);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Size = new System.Drawing.Size(600, 44);
            this.pnlTop.TabIndex = 2;

            this.txtSearch.Name = "txtSearch";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Location = new System.Drawing.Point(12, 10);
            this.txtSearch.PlaceholderText = "Search the menu";
            this.txtSearch.Size = new System.Drawing.Size(220, 23);
            this.txtSearch.TabIndex = 0;

            this.cmbCategory.Items.AddRange(new object[] {
                "All",
                "Burgers",
                "Sides",
                "Drinks",
                "Desserts"});
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Location = new System.Drawing.Point(244, 10);
            this.cmbCategory.Size = new System.Drawing.Size(160, 23);
            this.cmbCategory.TabIndex = 1;

            this.grpCart.Controls.Add(this.btnExtras);
            this.grpCart.Controls.Add(this.btnRemove);
            this.grpCart.Controls.Add(this.btnClear);
            this.grpCart.Controls.Add(this.dgvCart);
            this.grpCart.Controls.Add(this.lblSubtotalCap);
            this.grpCart.Controls.Add(this.lblSubtotal);
            this.grpCart.Controls.Add(this.lblTaxCap);
            this.grpCart.Controls.Add(this.lblTax);
            this.grpCart.Controls.Add(this.lblTotalCap);
            this.grpCart.Controls.Add(this.lblTotal);
            this.grpCart.Controls.Add(this.grpPay);
            this.grpCart.Controls.Add(this.btnCheckout);
            this.grpCart.Controls.Add(this.lblNote);
            this.grpCart.Name = "grpCart";
            this.grpCart.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpCart.Location = new System.Drawing.Point(600, 0);
            this.grpCart.Size = new System.Drawing.Size(400, 620);
            this.grpCart.Text = "Current order";
            this.grpCart.TabIndex = 3;

            this.btnExtras.Name = "btnExtras";
            this.btnExtras.Click += new System.EventHandler(this.btnExtras_Click);
            this.btnExtras.Location = new System.Drawing.Point(12, 24);
            this.btnExtras.Size = new System.Drawing.Size(90, 30);
            this.btnExtras.Text = "Extras...";
            this.btnExtras.UseVisualStyleBackColor = true;
            this.btnExtras.TabIndex = 0;

            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            this.btnRemove.Location = new System.Drawing.Point(108, 24);
            this.btnRemove.Size = new System.Drawing.Size(80, 30);
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.TabIndex = 1;

            this.btnClear.Name = "btnClear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.Location = new System.Drawing.Point(194, 24);
            this.btnClear.Size = new System.Drawing.Size(70, 30);
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.TabIndex = 2;

            this.dgvCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colItem,
                this.colExtras,
                this.colQty,
                this.colPrice,
                this.colTotal});
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.SelectionChanged += new System.EventHandler(this.dgvCart_SelectionChanged);
            this.dgvCart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCart_KeyDown);
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.ReadOnly = true;
            this.dgvCart.MultiSelect = false;
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.Location = new System.Drawing.Point(12, 64);
            this.dgvCart.Size = new System.Drawing.Size(376, 260);
            this.dgvCart.TabIndex = 3;

            this.colItem.Name = "colItem";
            this.colItem.HeaderText = "Item";

            this.colExtras.Name = "colExtras";
            this.colExtras.HeaderText = "Extras";

            this.colQty.Name = "colQty";
            this.colQty.HeaderText = "Qty";

            this.colPrice.Name = "colPrice";
            this.colPrice.HeaderText = "Price";

            this.colTotal.Name = "colTotal";
            this.colTotal.HeaderText = "Total";

            this.lblSubtotalCap.Name = "lblSubtotalCap";
            this.lblSubtotalCap.AutoSize = true;
            this.lblSubtotalCap.Location = new System.Drawing.Point(12, 338);
            this.lblSubtotalCap.Text = "Subtotal";
            this.lblSubtotalCap.TabIndex = 4;

            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Location = new System.Drawing.Point(250, 338);
            this.lblSubtotal.Size = new System.Drawing.Size(138, 23);
            this.lblSubtotal.Text = "195.00";
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSubtotal.TabIndex = 5;

            this.lblTaxCap.Name = "lblTaxCap";
            this.lblTaxCap.AutoSize = true;
            this.lblTaxCap.Location = new System.Drawing.Point(12, 364);
            this.lblTaxCap.Text = "Tax (14%)";
            this.lblTaxCap.TabIndex = 6;

            this.lblTax.Name = "lblTax";
            this.lblTax.Location = new System.Drawing.Point(250, 364);
            this.lblTax.Size = new System.Drawing.Size(138, 23);
            this.lblTax.Text = "27.30";
            this.lblTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTax.TabIndex = 7;

            this.lblTotalCap.Name = "lblTotalCap";
            this.lblTotalCap.AutoSize = true;
            this.lblTotalCap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCap.Location = new System.Drawing.Point(12, 398);
            this.lblTotalCap.Text = "Total";
            this.lblTotalCap.TabIndex = 8;

            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(200, 390);
            this.lblTotal.Size = new System.Drawing.Size(188, 36);
            this.lblTotal.Text = "222.30";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotal.TabIndex = 9;

            this.grpPay.Controls.Add(this.rbCash);
            this.grpPay.Controls.Add(this.rbCard);
            this.grpPay.Name = "grpPay";
            this.grpPay.Location = new System.Drawing.Point(12, 436);
            this.grpPay.Size = new System.Drawing.Size(376, 56);
            this.grpPay.Text = "Payment";
            this.grpPay.TabIndex = 10;

            this.rbCash.Name = "rbCash";
            this.rbCash.AutoSize = true;
            this.rbCash.Checked = true;
            this.rbCash.Location = new System.Drawing.Point(16, 24);
            this.rbCash.TabStop = true;
            this.rbCash.Text = "Cash";
            this.rbCash.UseVisualStyleBackColor = true;
            this.rbCash.TabIndex = 0;

            this.rbCard.Name = "rbCard";
            this.rbCard.AutoSize = true;
            this.rbCard.Location = new System.Drawing.Point(120, 24);
            this.rbCard.Text = "Card";
            this.rbCard.UseVisualStyleBackColor = true;
            this.rbCard.TabIndex = 1;

            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckout.Location = new System.Drawing.Point(12, 500);
            this.btnCheckout.Size = new System.Drawing.Size(376, 44);
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.TabIndex = 11;

            this.lblNote.Name = "lblNote";
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(12, 556);
            this.lblNote.Text = "";
            this.lblNote.TabIndex = 12;

            this.Controls.Add(this.flpMenu);
            this.Controls.Add(this.grpExtras);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.grpCart);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "OrderForm";
            this.ClientSize = new System.Drawing.Size(1000, 620);
            this.Text = "New order";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OrderForm_KeyDown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrderForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.flpMenu.ResumeLayout(false);
            this.flpMenu.PerformLayout();
            this.grpExtras.ResumeLayout(false);
            this.grpExtras.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpCart.ResumeLayout(false);
            this.grpCart.PerformLayout();
            this.grpPay.ResumeLayout(false);
            this.grpPay.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpMenu;
        private System.Windows.Forms.GroupBox grpExtras;
        private System.Windows.Forms.FlowLayoutPanel flpExtras;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.NumericUpDown numQty;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.GroupBox grpCart;
        private System.Windows.Forms.Button btnExtras;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExtras;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.Label lblSubtotalCap;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblTaxCap;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblTotalCap;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.GroupBox grpPay;
        private System.Windows.Forms.RadioButton rbCash;
        private System.Windows.Forms.RadioButton rbCard;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Label lblNote;
    }
}
