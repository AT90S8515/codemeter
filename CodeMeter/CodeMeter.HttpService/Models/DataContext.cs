using System.Data.Entity;

namespace CodeMeter.HttpService.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("CodeMeter")
        {}

        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskLog> TaskLogs { get; set; }
    }
}