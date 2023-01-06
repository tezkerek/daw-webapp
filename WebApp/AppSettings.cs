namespace WebApp;

public class AppSettings
{
    public required string JwtSecret { get; set; }
    public required string JwtIssuer { get; set; }
    public required string JwtAudience { get; set; }
    public required string DbConnectionString { get; set; }
}