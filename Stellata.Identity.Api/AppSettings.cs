namespace Stellata.Identity.Api;

public class AppSettings
{
    public ConnectionStringsSettings ConnectionStrings { get; set; }
    public class ConnectionStringsSettings
    {
        public string Test { get; set; }
    }
}