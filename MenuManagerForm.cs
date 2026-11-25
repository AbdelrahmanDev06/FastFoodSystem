namespace FastFoodPOS;

public partial class MenuManagerForm : Form
{
    private bool refreshing;

    public MenuManagerForm()
    {
        InitializeComponent();
        Theme.Apply(this);
    }

    private void MenuManagerForm_Load(object sender, EventArgs e)
    {
        LoadCategoryLists();
        RefreshItems(null);
        RefreshCategories(null);
        RefreshAddOns(null);
    }

    private void MenuManagerForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape) Close();
    }

    private void Warn(string text)
    {
        MessageBox.Show(text, App.Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private bool Confirm(string text)
    {
        return MessageBox.Show(text, App.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
    }

    private void PriceBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        TextBox box = (TextBox)sender;
        if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar)) return;
        if (e.KeyChar == '.' && !box.Text.Contains('.')) return;
        e.Handled = true;
    }

    private void LoadCategoryLists()
    {
        string filter = cmbFilter.SelectedItem as string;
        cmbFilter.Items.Clear();
        cmbFilter.Items.Add("All");
        foreach (string category in DataStore.Categories)
            cmbFilter.Items.Add(category);
        int filterIndex = filter == null ? 0 : cmbFilter.Items.IndexOf(filter);
        cmbFilter.SelectedIndex = filterIndex < 0 ? 0 : filterIndex;

        string chosen = cmbItemCategory.SelectedItem as string;
        cmbItemCategory.Items.Clear();
        foreach (string category in DataStore.Categories.OrderBy(c => c))
            cmbItemCategory.Items.Add(category);
        int chosenIndex = chosen == null ? 0 : cmbItemCategory.Items.IndexOf(chosen);
        if (cmbItemCategory.Items.Count > 0)
            cmbItemCategory.SelectedIndex = chosenIndex < 0 ? 0 : chosenIndex;
    }

    private void RefreshItems(MenuItemInfo select)
    {
        string filter = cmbFilter.SelectedItem as string ?? "All";
        string search = txtSearchItems.Text.Trim();

        refreshing = true;
        dgvItems.Rows.Clear();

        IEnumerable<MenuItemInfo> shown = DataStore.Items
            .Where(i => filter == "All" || i.Category == filter)
            .Where(i => search.Length == 0 || i.Name.Contains(search, StringComparison.OrdinalIgnoreCase))
            .OrderBy(i => i.Category)
            .ThenBy(i => i.Name);

        foreach (MenuItemInfo item in shown)
        {
            int r = dgvItems.Rows.Add(item.Name, Fmt.Money(item.Price), item.Category, item.Available ? "Yes" : "No");
            dgvItems.Rows[r].Tag = item;
        }

        dgvItems.ClearSelection();
        if (select != null)
        {
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (ReferenceEquals(row.Tag, select))
                {
                    row.Selected = true;
                    dgvItems.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }
        refreshing = false;

        MenuItemInfo current = SelectedItem();
        if (current != null) ShowItem(current);
    }

    private MenuItemInfo SelectedItem()
    {
        if (dgvItems.SelectedRows.Count == 0) return null;
        return dgvItems.SelectedRows[0].Tag as MenuItemInfo;
    }

    private void ShowItem(MenuItemInfo item)
    {
        if (item == null)
        {
            txtItemName.Clear();
            txtItemPrice.Clear();
            chkAvailable.Checked = true;
            if (cmbItemCategory.Items.Count > 0) cmbItemCategory.SelectedIndex = 0;
            return;
        }

        txtItemName.Text = item.Name;
        txtItemPrice.Text = Fmt.Money(item.Price).Replace(",", "");
        cmbItemCategory.SelectedItem = item.Category;
        chkAvailable.Checked = item.Available;
    }

    private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        RefreshItems(SelectedItem());
    }

    private void txtSearchItems_TextChanged(object sender, EventArgs e)
    {
        RefreshItems(SelectedItem());
    }

    private void dgvItems_SelectionChanged(object sender, EventArgs e)
    {
        if (refreshing) return;
        ShowItem(SelectedItem());
    }

    private bool ReadItemInput(MenuItemInfo editing, out string name, out decimal price, out string category)
    {
        name = "";
        price = 0m;
        category = null;

        string typedName = txtItemName.Text.Trim();
        if (typedName.Length == 0)
        {
            Warn("Enter the item name.");
            txtItemName.Focus();
            return false;
        }

        decimal typedPrice;
        if (!Fmt.TryMoney(txtItemPrice.Text, out typedPrice) || typedPrice <= 0m)
        {
            Warn("Enter a price greater than zero, for example 45.50.");
            txtItemPrice.Focus();
            return false;
        }

        string chosenCategory = cmbItemCategory.SelectedItem as string;
        if (chosenCategory == null)
        {
            Warn("Choose a category.");
            cmbItemCategory.Focus();
            return false;
        }

        bool duplicate = DataStore.Items.Any(i => !ReferenceEquals(i, editing)
                                               && string.Equals(i.Name, typedName, StringComparison.OrdinalIgnoreCase));
        if (duplicate)
        {
            Warn("An item with this name already exists.");
            txtItemName.Focus();
            return false;
        }

        name = typedName;
        price = Math.Round(typedPrice, 2);
        category = chosenCategory;
        return true;
    }

    private void btnItemAdd_Click(object sender, EventArgs e)
    {
        string name, category;
        decimal price;
        if (!ReadItemInput(null, out name, out price, out category)) return;

        MenuItemInfo item = new MenuItemInfo { Name = name, Price = price, Category = category, Available = chkAvailable.Checked };
        DataStore.Items.Add(item);
        RefreshItems(item);
    }

    private void btnItemUpdate_Click(object sender, EventArgs e)
    {
        MenuItemInfo item = SelectedItem();
        if (item == null)
        {
            Warn("Select an item in the list first.");
            return;
        }

        string name, category;
        decimal price;
        if (!ReadItemInput(item, out name, out price, out category)) return;

        item.Name = name;
        item.Price = price;
        item.Category = category;
        item.Available = chkAvailable.Checked;
        RefreshItems(item);
    }

    private void btnItemDelete_Click(object sender, EventArgs e)
    {
        MenuItemInfo item = SelectedItem();
        if (item == null)
        {
            Warn("Select an item in the list first.");
            return;
        }
        if (!Confirm("Delete \"" + item.Name + "\" from the menu?")) return;

        DataStore.Items.Remove(item);
        RefreshItems(null);
        ShowItem(null);
    }

    private void btnItemClear_Click(object sender, EventArgs e)
    {
        dgvItems.ClearSelection();
        ShowItem(null);
        txtItemName.Focus();
    }

    private void RefreshCategories(string select)
    {
        refreshing = true;
        dgvCategories.Rows.Clear();
        foreach (string category in DataStore.Categories.OrderBy(c => c))
        {
            int r = dgvCategories.Rows.Add(category);
            dgvCategories.Rows[r].Tag = category;
        }

        dgvCategories.ClearSelection();
        if (select != null)
        {
            foreach (DataGridViewRow row in dgvCategories.Rows)
            {
                if ((string)row.Tag == select)
                {
                    row.Selected = true;
                    dgvCategories.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }
        refreshing = false;

        txtCategoryName.Text = SelectedCategory() ?? "";
    }

    private string SelectedCategory()
    {
        if (dgvCategories.SelectedRows.Count == 0) return null;
        return dgvCategories.SelectedRows[0].Tag as string;
    }

    private void dgvCategories_SelectionChanged(object sender, EventArgs e)
    {
        if (refreshing) return;
        txtCategoryName.Text = SelectedCategory() ?? "";
    }

    private bool CategoryNameTaken(string name, string except)
    {
        return DataStore.Categories.Any(c => c != except && string.Equals(c, name, StringComparison.OrdinalIgnoreCase));
    }

    private void btnCategoryAdd_Click(object sender, EventArgs e)
    {
        string name = txtCategoryName.Text.Trim();
        if (name.Length == 0)
        {
            Warn("Enter the category name.");
            txtCategoryName.Focus();
            return;
        }
        if (CategoryNameTaken(name, null))
        {
            Warn("This category already exists.");
            txtCategoryName.Focus();
            return;
        }

        DataStore.Categories.Add(name);
        LoadCategoryLists();
        RefreshCategories(name);
    }

    private void btnCategoryRename_Click(object sender, EventArgs e)
    {
        string oldName = SelectedCategory();
        if (oldName == null)
        {
            Warn("Select a category in the list first.");
            return;
        }

        string newName = txtCategoryName.Text.Trim();
        if (newName.Length == 0)
        {
            Warn("Enter the new category name.");
            txtCategoryName.Focus();
            return;
        }
        if (CategoryNameTaken(newName, oldName))
        {
            Warn("Another category already has this name.");
            txtCategoryName.Focus();
            return;
        }

        DataStore.RenameCategory(oldName, newName);
        LoadCategoryLists();
        RefreshItems(null);
        RefreshCategories(newName);
    }

    private void btnCategoryDelete_Click(object sender, EventArgs e)
    {
        string name = SelectedCategory();
        if (name == null)
        {
            Warn("Select a category in the list first.");
            return;
        }
        if (DataStore.CategoryInUse(name))
        {
            Warn("\"" + name + "\" still has menu items. Move or delete those items first.");
            return;
        }
        if (!Confirm("Delete the category \"" + name + "\"?")) return;

        DataStore.Categories.Remove(name);
        LoadCategoryLists();
        RefreshCategories(null);
    }

    private void RefreshAddOns(AddOn select)
    {
        refreshing = true;
        dgvAddOns.Rows.Clear();
        foreach (AddOn addOn in DataStore.AddOns.OrderBy(a => a.Name))
        {
            int r = dgvAddOns.Rows.Add(addOn.Name, Fmt.Money(addOn.Price));
            dgvAddOns.Rows[r].Tag = addOn;
        }

        dgvAddOns.ClearSelection();
        if (select != null)
        {
            foreach (DataGridViewRow row in dgvAddOns.Rows)
            {
                if (ReferenceEquals(row.Tag, select))
                {
                    row.Selected = true;
                    dgvAddOns.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }
        refreshing = false;

        ShowAddOn(SelectedAddOn());
    }

    private AddOn SelectedAddOn()
    {
        if (dgvAddOns.SelectedRows.Count == 0) return null;
        return dgvAddOns.SelectedRows[0].Tag as AddOn;
    }

    private void ShowAddOn(AddOn addOn)
    {
        if (addOn == null)
        {
            txtAddOnName.Clear();
            txtAddOnPrice.Clear();
            return;
        }
        txtAddOnName.Text = addOn.Name;
        txtAddOnPrice.Text = Fmt.Money(addOn.Price).Replace(",", "");
    }

    private void dgvAddOns_SelectionChanged(object sender, EventArgs e)
    {
        if (refreshing) return;
        ShowAddOn(SelectedAddOn());
    }

    private bool ReadAddOnInput(AddOn editing, out string name, out decimal price)
    {
        name = "";
        price = 0m;

        string typedName = txtAddOnName.Text.Trim();
        if (typedName.Length == 0)
        {
            Warn("Enter the add-on name.");
            txtAddOnName.Focus();
            return false;
        }

        decimal typedPrice;
        if (!Fmt.TryMoney(txtAddOnPrice.Text, out typedPrice) || typedPrice <= 0m)
        {
            Warn("Enter a price greater than zero, for example 12.00.");
            txtAddOnPrice.Focus();
            return false;
        }

        bool duplicate = DataStore.AddOns.Any(a => !ReferenceEquals(a, editing)
                                                 && string.Equals(a.Name, typedName, StringComparison.OrdinalIgnoreCase));
        if (duplicate)
        {
            Warn("An add-on with this name already exists.");
            txtAddOnName.Focus();
            return false;
        }

        name = typedName;
        price = Math.Round(typedPrice, 2);
        return true;
    }

    private void btnAddOnAdd_Click(object sender, EventArgs e)
    {
        string name;
        decimal price;
        if (!ReadAddOnInput(null, out name, out price)) return;

        AddOn addOn = new AddOn { Name = name, Price = price };
        DataStore.AddOns.Add(addOn);
        RefreshAddOns(addOn);
    }

    private void btnAddOnUpdate_Click(object sender, EventArgs e)
    {
        AddOn addOn = SelectedAddOn();
        if (addOn == null)
        {
            Warn("Select an add-on in the list first.");
            return;
        }

        string name;
        decimal price;
        if (!ReadAddOnInput(addOn, out name, out price)) return;

        addOn.Name = name;
        addOn.Price = price;
        RefreshAddOns(addOn);
    }

    private void btnAddOnDelete_Click(object sender, EventArgs e)
    {
        AddOn addOn = SelectedAddOn();
        if (addOn == null)
        {
            Warn("Select an add-on in the list first.");
            return;
        }
        if (!Confirm("Delete the add-on \"" + addOn.Name + "\"?")) return;

        DataStore.AddOns.Remove(addOn);
        RefreshAddOns(null);
    }
}
