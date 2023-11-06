using Microsoft.EntityFrameworkCore;
using TaskerAPI.Models;

namespace TaskerAPI.Data
{
    public class TaskerAPIDbContext: DbContext
    {
        public TaskerAPIDbContext(DbContextOptions<TaskerAPIDbContext> options) : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonProject> PeopleProject { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Models.TaskStatus> TasksStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonProject>()
                .HasKey(pp => new { pp.PersonId, pp.ProjectId });
        }
    }
}
