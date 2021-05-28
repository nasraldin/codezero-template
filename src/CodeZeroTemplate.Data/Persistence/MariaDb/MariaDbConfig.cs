namespace CodeZeroTemplate.Data.Persistence.MariaDb
{
    public class MariaDbConfig
    {
        public string? ConnectionStrings { get; set; }
        public bool SensitiveDataLogging { get; set; } = false;
        public bool EnableDetailedErrors { get; set; } = false;
    }
}