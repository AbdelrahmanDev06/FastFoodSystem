namespace FastFoodPOS;

public static class Theme
{
    static readonly Color Red = Color.FromArgb(214, 58, 38), DarkRed = Color.FromArgb(168, 36, 42);
    static readonly Color Page = Color.FromArgb(240, 239, 236), Header = Color.FromArgb(244, 243, 240);

    public static readonly Color Selection = Color.FromArgb(250, 230, 226);
    public static readonly Color Ink = Color.FromArgb(30, 30, 30), Line = Color.FromArgb(221, 221, 217);
    public static readonly Color Green = Color.FromArgb(91, 140, 58), Blue = Color.FromArgb(46, 109, 164);
    public static readonly Color Purple = Color.FromArgb(142, 91, 163), Gold = Color.FromArgb(201, 154, 30);

    public static readonly Brush AccentBrush = new SolidBrush(Red), BarBrush = new SolidBrush(Color.FromArgb(74, 72, 67));
    public static readonly Brush GreenBrush = new SolidBrush(Green), BlueBrush = new SolidBrush(Blue), GoldBrush = new SolidBrush(Gold);

    public static Color AccentColor => Red;
    public static Color BarColor => Color.FromArgb(74, 72, 67);

    public static Color CategoryColor(string category)
    {
        switch (category)
        {
            case "Burgers":  return Red;
            case "Sides":    return Blue;
            case "Drinks":   return Green;
            case "Desserts": return Gold;
            default:         return Purple;
        }
    }

    static readonly string[] Primary = { "btnLogin", "btnCheckout", "btnSearch", "btnGenerate", "btnItemAdd", "btnCategoryAdd", "btnAddOnAdd" };
    static readonly string[] WhitePanels = { "flpSide", "pnlBar", "pnlPie", "pnlStats" };

    public static void Apply(Control root)
    {
        if (root is Form) root.BackColor = Page;
        foreach (Control c in root.Controls)
        {
            if (c is Button b) StyleButton(b);
            else if (c is DataGridView g) StyleGrid(g);
            else if (c is GroupBox || c is ToolStrip || WhitePanels.Contains(c.Name)) c.BackColor = Color.White;
            Apply(c);
        }
    }

    public static void StylePrimary(Button b) => Flat(b, Red, Color.White, Red, DarkRed);

    static void StyleButton(Button b)
    {
        if (b.Parent?.Name == "flpSide")
        {
            Flat(b, Color.White, Ink, Color.White, Selection);
            b.FlatAppearance.BorderSize = 0;
            b.TextAlign = ContentAlignment.MiddleLeft;
            b.Padding = new Padding(14, 0, 0, 0);
        }
        else if (b.Name.Contains("Delete")) Flat(b, Color.White, DarkRed, DarkRed, Selection);
        else if (Primary.Contains(b.Name))  StylePrimary(b);
        else                                Flat(b, Color.White, Ink, Line, Selection);
    }

    static void Flat(Button b, Color back, Color fore, Color border, Color hover)
    {
        b.UseVisualStyleBackColor = false;
        b.FlatStyle = FlatStyle.Flat;
        b.Cursor = Cursors.Hand;
        b.BackColor = back;
        b.ForeColor = fore;
        b.Font = new Font(b.Font, FontStyle.Bold);
        b.FlatAppearance.BorderSize = 1;
        b.FlatAppearance.BorderColor = border;
        b.FlatAppearance.MouseOverBackColor = b.FlatAppearance.MouseDownBackColor = hover;
    }

    static void StyleGrid(DataGridView g)
    {
        g.BackgroundColor = Color.White;
        g.GridColor = Line;
        g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        g.EnableHeadersVisualStyles = false;
        g.ColumnHeadersDefaultCellStyle.BackColor = g.ColumnHeadersDefaultCellStyle.SelectionBackColor = Header;
        g.ColumnHeadersDefaultCellStyle.ForeColor = g.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(107, 107, 107);
        g.DefaultCellStyle.BackColor = Color.White;
        g.DefaultCellStyle.ForeColor = g.DefaultCellStyle.SelectionForeColor = Ink;
        g.DefaultCellStyle.SelectionBackColor = Selection;
    }
}
