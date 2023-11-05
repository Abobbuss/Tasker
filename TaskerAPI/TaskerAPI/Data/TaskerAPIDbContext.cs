using Microsoft.EntityFrameworkCore;
using TaskerAPI.Models;

namespace TaskerAPI.Data
{
    public class TaskerAPIDbContext: DbContext
    {
        public TaskerAPIDbContext(DbContextOptions<TaskerAPIDbContext> options) : base(options)
        {
        }

        public DbSet<Comment> comments { get; set; }
        public DbSet<Person> people { get; set; }
        public DbSet<PersonProject> peopleProject { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<Models.Task> tasks { get; set; }
        public DbSet<Models.TaskStatus> tasksStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonProject>()
                .HasKey(pp => new { pp.PersonId, pp.ProjectId });
        }
    }
}
