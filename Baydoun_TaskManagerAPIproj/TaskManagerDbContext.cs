using Microsoft.EntityFrameworkCore;

namespace Baydoun_TaskManagerAPIproj
{
    public class TaskDbcontext : DbContext
    {

        public DbSet<Task> Task { get; set; }
        public TaskDbcontext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=" + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Tasks.db");
        }
    }
}

