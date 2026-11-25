namespace FastFoodPOS;

public static class DataStore
{
    public const decimal TaxRate = 0.14m;

    public static List<string> Categories { get; } = new List<string> { "Burgers", "Sides", "Drinks", "Desserts" };
    public static List<MenuItemInfo> Items { get; } = new List<MenuItemInfo>();
    public static List<AddOn> AddOns { get; } = new List<AddOn>();
    public static List<Order> Orders { get; } = new List<Order>();
    public static List<KitchenTicket> Tickets { get; } = new List<KitchenTicket>();

    private static int nextOrderId = 100;

    static DataStore()
    {
        SeedMenu();
        SeedOrders();
        RestoreSampleTickets();
    }

    public static decimal ExtraPriceOf(string name)
    {
        AddOn found = AddOns.FirstOrDefault(a => a.Name == name);
        return found == null ? 0m : found.Price;
    }

    public static bool CategoryInUse(string name)
    {
        return Items.Any(i => i.Category == name);
    }

    public static void RenameCategory(string oldName, string newName)
    {
        int index = Categories.IndexOf(oldName);
        if (index < 0) return;

        Categories[index] = newName;
        foreach (MenuItemInfo item in Items.Where(i => i.Category == oldName))
            item.Category = newName;
        foreach (Order order in Orders)
            foreach (OrderLine line in order.Lines.Where(l => l.Category == oldName))
                line.Category = newName;
    }

    public static Order PlaceOrder(IEnumerable<OrderLine> lines, string payment)
    {
        Order order = new Order { Id = nextOrderId++, Date = DateTime.Now, Payment = payment, Status = "Paid" };
        foreach (OrderLine line in lines)
            order.Lines.Add(line.Clone());

        Orders.Add(order);
        Tickets.Add(TicketFor(order, order.Date));
        return order;
    }

    public static void DeleteOrder(Order order)
    {
        Orders.Remove(order);
        Tickets.RemoveAll(t => t.OrderNo == order.Id);
    }

    public static void CompleteTicket(KitchenTicket ticket)
    {
        Tickets.Remove(ticket);
    }

    public static void RestoreSampleTickets()
    {
        Tickets.Clear();

        int[] ages = { 14, 9, 6, 3, 0 };
        List<Order> recent = Orders.Where(o => !o.IsVoided)
                                   .OrderByDescending(o => o.Id)
                                   .Take(ages.Length)
                                   .OrderBy(o => o.Id)
                                   .ToList();

        int offset = ages.Length - recent.Count;
        for (int i = 0; i < recent.Count; i++)
            Tickets.Add(TicketFor(recent[i], DateTime.Now.AddMinutes(-ages[offset + i])));
    }

    private static KitchenTicket TicketFor(Order order, DateTime created)
    {
        List<string> rows = new List<string>();
        foreach (OrderLine line in order.Lines)
        {
            rows.Add(line.Qty + " x " + line.Item);
            foreach (string extra in line.Extras)
                rows.Add("   + " + extra);
        }
        return new KitchenTicket { OrderNo = order.Id, Created = created, Lines = string.Join("\r\n", rows) };
    }

    private static void AddItem(string name, decimal price, string category, bool available = true)
    {
        Items.Add(new MenuItemInfo { Name = name, Price = price, Category = category, Available = available });
    }

    private static void SeedMenu()
    {
        AddItem("Cheese Burger", 60m, "Burgers");
        AddItem("Double Burger", 85m, "Burgers");
        AddItem("Chicken Burger", 65m, "Burgers");
        AddItem("Crispy Chicken", 70m, "Burgers");
        AddItem("French Fries", 25m, "Sides");
        AddItem("Onion Rings", 30m, "Sides");
        AddItem("Coleslaw", 18m, "Sides");
        AddItem("Cola", 15m, "Drinks");
        AddItem("Orange Juice", 20m, "Drinks");
        AddItem("Water", 8m, "Drinks");
        AddItem("Ice Cream", 22m, "Desserts", false);
        AddItem("Brownie", 28m, "Desserts");

        AddOns.Add(new AddOn { Name = "Bacon", Price = 12m });
        AddOns.Add(new AddOn { Name = "Extra cheese", Price = 10m });
        AddOns.Add(new AddOn { Name = "Extra sauce", Price = 5m });
        AddOns.Add(new AddOn { Name = "Large size", Price = 15m });
    }

    private static void SeedOrders()
    {
        Random rnd = new Random(312);

        List<MenuItemInfo> pool = new List<MenuItemInfo>();
        foreach (MenuItemInfo item in Items.Where(i => i.Available))
        {
            int weight = item.Name == "Cheese Burger" ? 4
                       : item.Name == "French Fries" ? 3
                       : item.Name == "Cola" ? 3
                       : item.Name == "Double Burger" ? 2 : 1;
            for (int w = 0; w < weight; w++) pool.Add(item);
        }

        List<Order> seeded = new List<Order>();
        for (int back = 13; back >= 0; back--)
        {
            DateTime day = DateTime.Today.AddDays(-back);
            int ordersToday = 5 + rnd.Next(0, 8);

            for (int k = 0; k < ordersToday; k++)
            {
                DateTime when = day.AddHours(11).AddMinutes(rnd.Next(0, 660));
                if (when > DateTime.Now) continue;

                Order order = new Order
                {
                    Date = when,
                    Payment = rnd.Next(100) < 55 ? "Cash" : "Card",
                    Status = rnd.Next(100) < 4 ? "Voided" : "Paid"
                };

                int lineCount = rnd.Next(1, 4);
                for (int n = 0; n < lineCount; n++)
                {
                    MenuItemInfo item = pool[rnd.Next(pool.Count)];
                    OrderLine line = new OrderLine
                    {
                        Item = item.Name,
                        Category = item.Category,
                        BasePrice = item.Price,
                        Qty = rnd.Next(1, 4)
                    };
                    if (item.Category == "Burgers" && rnd.Next(100) < 35)
                        line.SetExtras(new[] { AddOns[rnd.Next(AddOns.Count)].Name });
                    order.Lines.Add(line);
                }
                seeded.Add(order);
            }
        }

        seeded = seeded.OrderBy(o => o.Date).ToList();
        foreach (Order order in seeded)
            order.Id = nextOrderId++;
        Orders.AddRange(seeded);
    }
}
