using Microsoft.EntityFrameworkCore;
using TodoList.Core.Entities;

namespace TodoList.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        #region DbSets
        public DbSet<Core.Entities.Task> Task { get; set; }
        public DbSet<TaskState> TaskState { get; set; }
        public DbSet<TaskCategory> TaskCategory { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Core.Entities.Task>()
                .Navigation(t => t.TaskState)
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            modelBuilder.Entity<Core.Entities.Task>()
                .Navigation(t => t.TaskCategory)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }

    }
}
