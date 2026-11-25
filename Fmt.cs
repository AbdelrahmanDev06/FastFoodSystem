using System.Globalization;

namespace FastFoodPOS;

public static class App
{
    public const string Title = "Smash House POS";
}

public static class Fmt
{
    public static string Money(decimal value) => value.ToString("N2", CultureInfo.InvariantCulture);

    public static string Whole(decimal value) => Math.Round(value).ToString("N0", CultureInfo.InvariantCulture);

    public static string Stamp(DateTime value) => value.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

    public static string DayMonth(DateTime value) => value.ToString("dd/MM", CultureInfo.InvariantCulture);

    public static string Int(int value) => value.ToString(CultureInfo.InvariantCulture);

    public static bool TryMoney(string text, out decimal value)
    {
        return decimal.TryParse((text ?? "").Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out value);
    }
}
