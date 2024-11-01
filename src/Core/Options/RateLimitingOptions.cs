namespace Core.Options;

public class RateLimitingOptions
{
    public const string Section = "RateLimiting";
    public int PermitLimit { get; set; }
    public int WindowSeconds { get; set; }
}
