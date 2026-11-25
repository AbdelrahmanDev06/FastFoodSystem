namespace FastFoodPOS;

public class MenuItemInfo
{
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public string Category { get; set; } = "";
    public bool Available { get; set; } = true;
}

public class AddOn
{
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
}

public class OrderLine
{
    public string Item { get; set; } = "";
    public string Category { get; set; } = "";
    public decimal BasePrice { get; set; }
    public int Qty { get; set; } = 1;

    public List<string> Extras { get; } = new List<string>();
    public decimal ExtraPrice { get; private set; }

    public decimal UnitPrice => BasePrice + ExtraPrice;
    public decimal Total => UnitPrice * Qty;
    public string ExtrasText => string.Join(", ", Extras);

    public void SetExtras(IEnumerable<string> names)
    {
        List<string> chosen = names.ToList();
        Extras.Clear();
        Extras.AddRange(chosen);
        ExtraPrice = Extras.Sum(n => DataStore.ExtraPriceOf(n));
    }

    public OrderLine Clone()
    {
        OrderLine copy = new OrderLine { Item = Item, Category = Category, BasePrice = BasePrice, Qty = Qty };
        copy.Extras.AddRange(Extras);
        copy.ExtraPrice = ExtraPrice;
        return copy;
    }
}

public class Order
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Payment { get; set; } = "Cash";
    public string Status { get; set; } = "Paid";
    public List<OrderLine> Lines { get; } = new List<OrderLine>();

    public bool IsVoided => Status == "Voided";
    public decimal Subtotal => Lines.Sum(l => l.Total);
    public decimal Tax => Math.Round(Subtotal * DataStore.TaxRate, 2);
    public decimal Total => Subtotal + Tax;
}

public class KitchenTicket
{
    public int OrderNo { get; set; }
    public DateTime Created { get; set; }
    public string Lines { get; set; } = "";

    public int AgeMinutes => Math.Max(0, (int)(DateTime.Now - Created).TotalMinutes);
}
