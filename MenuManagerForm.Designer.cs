namespace FastFoodPOS
{
    partial class MenuManagerForm
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabItems = new System.Windows.Forms.TabPage();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.txtSearchItems = new System.Windows.Forms.TextBox();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.grpItem = new System.Windows.Forms.GroupBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblItemPrice = new System.Windows.Forms.Label();
            this.txtItemPrice = new System.Windows.Forms.TextBox();
            this.lblItemCategory = new System.Windows.Forms.Label();
            this.cmbItemCategory = new System.Windows.Forms.ComboBox();
            this.chkAvailable = new System.Windows.Forms.CheckBox();
            this.btnItemAdd = new System.Windows.Forms.Button();
            this.btnItemUpdate = new System.Windows.Forms.Button();
            this.btnItemDelete = new System.Windows.Forms.Button();
            this.btnItemClear = new System.Windows.Forms.Button();
            this.tabCategories = new System.Windows.Forms.TabPage();
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.colCategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpCategory = new System.Windows.Forms.GroupBox();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.btnCategoryAdd = new System.Windows.Forms.Button();
            this.btnCategoryRename = new System.Windows.Forms.Button();
            this.btnCategoryDelete = new System.Windows.Forms.Button();
            this.tabAddOns = new System.Windows.Forms.TabPage();
            this.dgvAddOns = new System.Windows.Forms.DataGridView();
            this.colAddOnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddOnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpAddOn = new System.Windows.Forms.GroupBox();
            this.lblAddOnName = new System.Windows.Forms.Label();
            this.txtAddOnName = new System.Windows.Forms.TextBox();
            this.lblAddOnPrice = new System.Windows.Forms.Label();
            this.txtAddOnPrice = new System.Windows.Forms.TextBox();
            this.btnAddOnAdd = new System.Windows.Forms.Button();
            this.btnAddOnUpdate = new System.Windows.Forms.Button();
            this.btnAddOnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddOns)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabItems.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.grpItem.SuspendLayout();
            this.tabCategories.SuspendLayout();
            this.grpCategory.SuspendLayout();
            this.tabAddOns.SuspendLayout();
            this.grpAddOn.SuspendLayout();
            this.SuspendLayout();

            this.tabMain.Controls.Add(this.tabItems);
            this.tabMain.Controls.Add(this.tabCategories);
            this.tabMain.Controls.Add(this.tabAddOns);
            this.tabMain.Name = "tabMain";
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Size = new System.Drawing.Size(900, 560);
            this.tabMain.TabIndex = 0;

            this.tabItems.Controls.Add(this.dgvItems);
            this.tabItems.Controls.Add(this.pnlFilter);
            this.tabItems.Controls.Add(this.grpItem);
            this.tabItems.Name = "tabItems";
            this.tabItems.Text = "Menu items";
            this.tabItems.UseVisualStyleBackColor = true;
            this.tabItems.TabIndex = 0;

            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colItemName,
                this.colItemPrice,
                this.colItemCategory,
                this.colItemAvailable});
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.SelectionChanged += new System.EventHandler(this.dgvItems_SelectionChanged);
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.ReadOnly = true;
            this.dgvItems.MultiSelect = false;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.TabIndex = 0;

            this.colItemName.Name = "colItemName";
            this.colItemName.HeaderText = "Name";

            this.colItemPrice.Name = "colItemPrice";
            this.colItemPrice.HeaderText = "Price";

            this.colItemCategory.Name = "colItemCategory";
            this.colItemCategory.HeaderText = "Category";

            this.colItemAvailable.Name = "colItemAvailable";
            this.colItemAvailable.HeaderText = "Available";

            this.pnlFilter.Controls.Add(this.txtSearchItems);
            this.pnlFilter.Controls.Add(this.cmbFilter);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Size = new System.Drawing.Size(560, 44);
            this.pnlFilter.TabIndex = 1;

            this.txtSearchItems.Name = "txtSearchItems";
            this.txtSearchItems.TextChanged += new System.EventHandler(this.txtSearchItems_TextChanged);
            this.txtSearchItems.Location = new System.Drawing.Point(8, 10);
            this.txtSearchItems.PlaceholderText = "Search items";
            this.txtSearchItems.Size = new System.Drawing.Size(220, 23);
            this.txtSearchItems.TabIndex = 0;

            this.cmbFilter.Items.AddRange(new object[] {
                "All",
                "Burgers",
                "Sides",
                "Drinks",
                "Desserts"});
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.Location = new System.Drawing.Point(240, 10);
            this.cmbFilter.Size = new System.Drawing.Size(160, 23);
            this.cmbFilter.TabIndex = 1;

            this.grpItem.Controls.Add(this.lblItemName);
            this.grpItem.Controls.Add(this.txtItemName);
            this.grpItem.Controls.Add(this.lblItemPrice);
            this.grpItem.Controls.Add(this.txtItemPrice);
            this.grpItem.Controls.Add(this.lblItemCategory);
            this.grpItem.Controls.Add(this.cmbItemCategory);
            this.grpItem.Controls.Add(this.chkAvailable);
            this.grpItem.Controls.Add(this.btnItemAdd);
            this.grpItem.Controls.Add(this.btnItemUpdate);
            this.grpItem.Controls.Add(this.btnItemDelete);
            this.grpItem.Controls.Add(this.btnItemClear);
            this.grpItem.Name = "grpItem";
            this.grpItem.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpItem.Size = new System.Drawing.Size(300, 500);
            this.grpItem.Text = "Item details";
            this.grpItem.TabIndex = 2;

            this.lblItemName.Name = "lblItemName";
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(16, 28);
            this.lblItemName.Text = "Name";
            this.lblItemName.TabIndex = 0;

            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Location = new System.Drawing.Point(16, 48);
            this.txtItemName.Size = new System.Drawing.Size(268, 23);
            this.txtItemName.TabIndex = 1;

            this.lblItemPrice.Name = "lblItemPrice";
            this.lblItemPrice.AutoSize = true;
            this.lblItemPrice.Location = new System.Drawing.Point(16, 84);
            this.lblItemPrice.Text = "Price";
            this.lblItemPrice.TabIndex = 2;

            this.txtItemPrice.Name = "txtItemPrice";
            this.txtItemPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PriceBox_KeyPress);
            this.txtItemPrice.Location = new System.Drawing.Point(16, 104);
            this.txtItemPrice.Size = new System.Drawing.Size(268, 23);
            this.txtItemPrice.TabIndex = 3;

            this.lblItemCategory.Name = "lblItemCategory";
            this.lblItemCategory.AutoSize = true;
            this.lblItemCategory.Location = new System.Drawing.Point(16, 140);
            this.lblItemCategory.Text = "Category";
            this.lblItemCategory.TabIndex = 4;

            this.cmbItemCategory.Items.AddRange(new object[] {
                "Burgers",
                "Desserts",
                "Drinks",
                "Sides"});
            this.cmbItemCategory.Name = "cmbItemCategory";
            this.cmbItemCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemCategory.Location = new System.Drawing.Point(16, 160);
            this.cmbItemCategory.Size = new System.Drawing.Size(268, 23);
            this.cmbItemCategory.TabIndex = 5;

            this.chkAvailable.Name = "chkAvailable";
            this.chkAvailable.AutoSize = true;
            this.chkAvailable.Checked = true;
            this.chkAvailable.Location = new System.Drawing.Point(16, 198);
            this.chkAvailable.Text = "Available on the order screen";
            this.chkAvailable.UseVisualStyleBackColor = true;
            this.chkAvailable.TabIndex = 6;

            this.btnItemAdd.Name = "btnItemAdd";
            this.btnItemAdd.Click += new System.EventHandler(this.btnItemAdd_Click);
            this.btnItemAdd.Location = new System.Drawing.Point(16, 240);
            this.btnItemAdd.Size = new System.Drawing.Size(62, 32);
            this.btnItemAdd.Text = "Add";
            this.btnItemAdd.UseVisualStyleBackColor = true;
            this.btnItemAdd.TabIndex = 7;

            this.btnItemUpdate.Name = "btnItemUpdate";
            this.btnItemUpdate.Click += new System.EventHandler(this.btnItemUpdate_Click);
            this.btnItemUpdate.Location = new System.Drawing.Point(82, 240);
            this.btnItemUpdate.Size = new System.Drawing.Size(62, 32);
            this.btnItemUpdate.Text = "Update";
            this.btnItemUpdate.UseVisualStyleBackColor = true;
            this.btnItemUpdate.TabIndex = 8;

            this.btnItemDelete.Name = "btnItemDelete";
            this.btnItemDelete.Click += new System.EventHandler(this.btnItemDelete_Click);
            this.btnItemDelete.Location = new System.Drawing.Point(148, 240);
            this.btnItemDelete.Size = new System.Drawing.Size(62, 32);
            this.btnItemDelete.Text = "Delete";
            this.btnItemDelete.UseVisualStyleBackColor = true;
            this.btnItemDelete.TabIndex = 9;

            this.btnItemClear.Name = "btnItemClear";
            this.btnItemClear.Click += new System.EventHandler(this.btnItemClear_Click);
            this.btnItemClear.Location = new System.Drawing.Point(214, 240);
            this.btnItemClear.Size = new System.Drawing.Size(62, 32);
            this.btnItemClear.Text = "Clear";
            this.btnItemClear.UseVisualStyleBackColor = true;
            this.btnItemClear.TabIndex = 10;

            this.tabCategories.Controls.Add(this.dgvCategories);
            this.tabCategories.Controls.Add(this.grpCategory);
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.Text = "Categories";
            this.tabCategories.UseVisualStyleBackColor = true;
            this.tabCategories.TabIndex = 1;

            this.dgvCategories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colCategoryName});
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.SelectionChanged += new System.EventHandler(this.dgvCategories_SelectionChanged);
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.ReadOnly = true;
            this.dgvCategories.MultiSelect = false;
            this.dgvCategories.RowHeadersVisible = false;
            this.dgvCategories.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCategories.TabIndex = 0;

            this.colCategoryName.Name = "colCategoryName";
            this.colCategoryName.HeaderText = "Name";

            this.grpCategory.Controls.Add(this.lblCategoryName);
            this.grpCategory.Controls.Add(this.txtCategoryName);
            this.grpCategory.Controls.Add(this.btnCategoryAdd);
            this.grpCategory.Controls.Add(this.btnCategoryRename);
            this.grpCategory.Controls.Add(this.btnCategoryDelete);
            this.grpCategory.Name = "grpCategory";
            this.grpCategory.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpCategory.Size = new System.Drawing.Size(300, 500);
            this.grpCategory.Text = "Category details";
            this.grpCategory.TabIndex = 1;

            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Location = new System.Drawing.Point(16, 28);
            this.lblCategoryName.Text = "Name";
            this.lblCategoryName.TabIndex = 0;

            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Location = new System.Drawing.Point(16, 48);
            this.txtCategoryName.Size = new System.Drawing.Size(268, 23);
            this.txtCategoryName.TabIndex = 1;

            this.btnCategoryAdd.Name = "btnCategoryAdd";
            this.btnCategoryAdd.Click += new System.EventHandler(this.btnCategoryAdd_Click);
            this.btnCategoryAdd.Location = new System.Drawing.Point(16, 84);
            this.btnCategoryAdd.Size = new System.Drawing.Size(80, 32);
            this.btnCategoryAdd.Text = "Add";
            this.btnCategoryAdd.UseVisualStyleBackColor = true;
            this.btnCategoryAdd.TabIndex = 2;

            this.btnCategoryRename.Name = "btnCategoryRename";
            this.btnCategoryRename.Click += new System.EventHandler(this.btnCategoryRename_Click);
            this.btnCategoryRename.Location = new System.Drawing.Point(102, 84);
            this.btnCategoryRename.Size = new System.Drawing.Size(80, 32);
            this.btnCategoryRename.Text = "Rename";
            this.btnCategoryRename.UseVisualStyleBackColor = true;
            this.btnCategoryRename.TabIndex = 3;

            this.btnCategoryDelete.Name = "btnCategoryDelete";
            this.btnCategoryDelete.Click += new System.EventHandler(this.btnCategoryDelete_Click);
            this.btnCategoryDelete.Location = new System.Drawing.Point(188, 84);
            this.btnCategoryDelete.Size = new System.Drawing.Size(80, 32);
            this.btnCategoryDelete.Text = "Delete";
            this.btnCategoryDelete.UseVisualStyleBackColor = true;
            this.btnCategoryDelete.TabIndex = 4;

            this.tabAddOns.Controls.Add(this.dgvAddOns);
            this.tabAddOns.Controls.Add(this.grpAddOn);
            this.tabAddOns.Name = "tabAddOns";
            this.tabAddOns.Text = "Add-ons";
            this.tabAddOns.UseVisualStyleBackColor = true;
            this.tabAddOns.TabIndex = 2;

            this.dgvAddOns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colAddOnName,
                this.colAddOnPrice});
            this.dgvAddOns.Name = "dgvAddOns";
            this.dgvAddOns.SelectionChanged += new System.EventHandler(this.dgvAddOns_SelectionChanged);
            this.dgvAddOns.AllowUserToAddRows = false;
            this.dgvAddOns.AllowUserToDeleteRows = false;
            this.dgvAddOns.ReadOnly = true;
            this.dgvAddOns.MultiSelect = false;
            this.dgvAddOns.RowHeadersVisible = false;
            this.dgvAddOns.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvAddOns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAddOns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAddOns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAddOns.TabIndex = 0;

            this.colAddOnName.Name = "colAddOnName";
            this.colAddOnName.HeaderText = "Name";

            this.colAddOnPrice.Name = "colAddOnPrice";
            this.colAddOnPrice.HeaderText = "Price";

            this.grpAddOn.Controls.Add(this.lblAddOnName);
            this.grpAddOn.Controls.Add(this.txtAddOnName);
            this.grpAddOn.Controls.Add(this.lblAddOnPrice);
            this.grpAddOn.Controls.Add(this.txtAddOnPrice);
            this.grpAddOn.Controls.Add(this.btnAddOnAdd);
            this.grpAddOn.Controls.Add(this.btnAddOnUpdate);
            this.grpAddOn.Controls.Add(this.btnAddOnDelete);
            this.grpAddOn.Name = "grpAddOn";
            this.grpAddOn.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpAddOn.Size = new System.Drawing.Size(300, 500);
            this.grpAddOn.Text = "Add-on details";
            this.grpAddOn.TabIndex = 1;

            this.lblAddOnName.Name = "lblAddOnName";
            this.lblAddOnName.AutoSize = true;
            this.lblAddOnName.Location = new System.Drawing.Point(16, 28);
            this.lblAddOnName.Text = "Name";
            this.lblAddOnName.TabIndex = 0;

            this.txtAddOnName.Name = "txtAddOnName";
            this.txtAddOnName.Location = new System.Drawing.Point(16, 48);
            this.txtAddOnName.Size = new System.Drawing.Size(268, 23);
            this.txtAddOnName.TabIndex = 1;

            this.lblAddOnPrice.Name = "lblAddOnPrice";
            this.lblAddOnPrice.AutoSize = true;
            this.lblAddOnPrice.Location = new System.Drawing.Point(16, 84);
            this.lblAddOnPrice.Text = "Price";
            this.lblAddOnPrice.TabIndex = 2;

            this.txtAddOnPrice.Name = "txtAddOnPrice";
            this.txtAddOnPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PriceBox_KeyPress);
            this.txtAddOnPrice.Location = new System.Drawing.Point(16, 104);
            this.txtAddOnPrice.Size = new System.Drawing.Size(268, 23);
            this.txtAddOnPrice.TabIndex = 3;

            this.btnAddOnAdd.Name = "btnAddOnAdd";
            this.btnAddOnAdd.Click += new System.EventHandler(this.btnAddOnAdd_Click);
            this.btnAddOnAdd.Location = new System.Drawing.Point(16, 148);
            this.btnAddOnAdd.Size = new System.Drawing.Size(80, 32);
            this.btnAddOnAdd.Text = "Add";
            this.btnAddOnAdd.UseVisualStyleBackColor = true;
            this.btnAddOnAdd.TabIndex = 4;

            this.btnAddOnUpdate.Name = "btnAddOnUpdate";
            this.btnAddOnUpdate.Click += new System.EventHandler(this.btnAddOnUpdate_Click);
            this.btnAddOnUpdate.Location = new System.Drawing.Point(102, 148);
            this.btnAddOnUpdate.Size = new System.Drawing.Size(80, 32);
            this.btnAddOnUpdate.Text = "Update";
            this.btnAddOnUpdate.UseVisualStyleBackColor = true;
            this.btnAddOnUpdate.TabIndex = 5;

            this.btnAddOnDelete.Name = "btnAddOnDelete";
            this.btnAddOnDelete.Click += new System.EventHandler(this.btnAddOnDelete_Click);
            this.btnAddOnDelete.Location = new System.Drawing.Point(188, 148);
            this.btnAddOnDelete.Size = new System.Drawing.Size(80, 32);
            this.btnAddOnDelete.Text = "Delete";
            this.btnAddOnDelete.UseVisualStyleBackColor = true;
            this.btnAddOnDelete.TabIndex = 6;

            this.Controls.Add(this.tabMain);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "MenuManagerForm";
            this.ClientSize = new System.Drawing.Size(900, 560);
            this.Text = "Menu manager";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.MenuManagerForm_Load);
            this.KeyPreview = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MenuManagerForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddOns)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            this.tabItems.ResumeLayout(false);
            this.tabItems.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.grpItem.ResumeLayout(false);
            this.grpItem.PerformLayout();
            this.tabCategories.ResumeLayout(false);
            this.tabCategories.PerformLayout();
            this.grpCategory.ResumeLayout(false);
            this.grpCategory.PerformLayout();
            this.tabAddOns.ResumeLayout(false);
            this.tabAddOns.PerformLayout();
            this.grpAddOn.ResumeLayout(false);
            this.grpAddOn.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabItems;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemAvailable;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.TextBox txtSearchItems;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.GroupBox grpItem;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label lblItemPrice;
        private System.Windows.Forms.TextBox txtItemPrice;
        private System.Windows.Forms.Label lblItemCategory;
        private System.Windows.Forms.ComboBox cmbItemCategory;
        private System.Windows.Forms.CheckBox chkAvailable;
        private System.Windows.Forms.Button btnItemAdd;
        private System.Windows.Forms.Button btnItemUpdate;
        private System.Windows.Forms.Button btnItemDelete;
        private System.Windows.Forms.Button btnItemClear;
        private System.Windows.Forms.TabPage tabCategories;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoryName;
        private System.Windows.Forms.GroupBox grpCategory;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Button btnCategoryAdd;
        private System.Windows.Forms.Button btnCategoryRename;
        private System.Windows.Forms.Button btnCategoryDelete;
        private System.Windows.Forms.TabPage tabAddOns;
        private System.Windows.Forms.DataGridView dgvAddOns;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddOnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddOnPrice;
        private System.Windows.Forms.GroupBox grpAddOn;
        private System.Windows.Forms.Label lblAddOnName;
        private System.Windows.Forms.TextBox txtAddOnName;
        private System.Windows.Forms.Label lblAddOnPrice;
        private System.Windows.Forms.TextBox txtAddOnPrice;
        private System.Windows.Forms.Button btnAddOnAdd;
        private System.Windows.Forms.Button btnAddOnUpdate;
        private System.Windows.Forms.Button btnAddOnDelete;
    }
}
