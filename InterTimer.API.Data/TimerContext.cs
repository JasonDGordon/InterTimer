using InterTimer.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InterTimer.API.Data
{
    internal class TimerContext: DbContext
    {
        public TimerContext(): base()
        {
        }

        internal DbSet<Client> Clients { get; set; }
        internal DbSet<Project> Projects { get; set; }
        internal DbSet<ProjectTask> ProjectTasks { get; set; }
        internal DbSet<TimeEntry> TimeEntries { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
