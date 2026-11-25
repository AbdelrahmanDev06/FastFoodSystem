using System.ComponentModel;

namespace FastFoodPOS;

public class MenuTile : Button
{
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public MenuItemInfo Item { get; }

    public MenuTile(MenuItemInfo item)
    {
        Item = item;

        Text = item.Name + "\r\n" + Fmt.Money(item.Price);
        Size = new Size(130, 80);
        Margin = new Padding(6);
        Padding = new Padding(10, 0, 0, 0);
        TextAlign = ContentAlignment.MiddleLeft;
        Cursor = Cursors.Hand;

        UseVisualStyleBackColor = false;
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderColor = Theme.Line;
        FlatAppearance.MouseOverBackColor = Theme.Selection;
        BackColor = Color.White;
        ForeColor = Theme.Ink;
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);

        using (SolidBrush stripe = new SolidBrush(Theme.CategoryColor(Item.Category)))
            pevent.Graphics.FillRectangle(stripe, 0, 0, 5, Height);
    }
}
