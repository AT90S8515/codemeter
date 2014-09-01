using System.Data.Entity;

namespace CodeMeter.HttpService.Models
{
    public class DataContext : DbContext
    {
        static DataContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Migrations.Configuration>());
        }

        public DataContext() : base("CodeMeter")
        {}

        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskLog> TaskLogs { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
    }
}