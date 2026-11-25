namespace FastFoodPOS;

public enum UserRole { Cashier, Admin, Chef }

public static class Session
{
    public static string UserName { get; private set; } = "";
    public static UserRole Role { get; private set; } = UserRole.Cashier;
    public static bool IsAdmin => Role == UserRole.Admin;
    public static bool IsChef => Role == UserRole.Chef;

    public static bool TryLogin(string username, string password)
    {
        username = username.Trim().ToLower();

        if (username == "admin" && password == "admin123") { UserName = username; Role = UserRole.Admin; return true; }
        if (username == "cash" && password == "cash123") { UserName = username; Role = UserRole.Cashier; return true; }
        if (username == "kitchen" && password == "kitchen123") { UserName = username; Role = UserRole.Chef; return true; }
        return false;
    }

    public static void Clear()
    {
        UserName = "";
        Role = UserRole.Cashier;
    }
}
