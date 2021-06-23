using System;
namespace PSV2.Configuration
{
    public class ProjectConfiguration
    {
        public DatabaseConfiguration DatabaseConfiguration { get; set; } = new DatabaseConfiguration();
    }

    public class DatabaseConfiguration
    {
        public string ConnectionString { get; set; }
    }
}
