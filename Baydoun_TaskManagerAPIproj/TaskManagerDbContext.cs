using Microsoft.EntityFrameworkCore;

namespace Baydoun_TaskManagerAPIproj
{
    public class TaskDbContext : DbContext
    {

        public DbSet<Task> Task { get; set; }
        public TaskDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=" + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Tasks.db"));
        }

        public static implicit operator Task(TaskDbContext v)
        {
            throw new NotImplementedException();
        }
    }
}

