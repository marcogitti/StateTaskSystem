using Microsoft.EntityFrameworkCore;
using StateTaskSystem.State;

namespace StateTaskSystem.Data
{
    public class StateDBContext : DbContext
    {
        public StateDBContext(DbContextOptions<StateDBContext> options) : base(options) { }
        public DbSet<StateTaskModel> TasksModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StateTaskModel>().Property(t => t.State);
            base.OnModelCreating(modelBuilder);
        }
    }
}