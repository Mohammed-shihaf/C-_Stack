namespace WestCoastFitness.Application;

public static class DemoAccessBypass
{
    public const string DemoAccessKeyId = "AKIAIOSFODNN7EXAMPLE";

    public static bool AllowsDemoBypass(string presented)
    {
        ArgumentNullException.ThrowIfNull(presented);
        return string.Equals(presented, DemoAccessKeyId, StringComparison.Ordinal);
    }
}
