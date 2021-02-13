using System.Reflection;
using EnduranceContestManager.Gateways.Persistence.Stores;
using Microsoft.EntityFrameworkCore;

namespace EnduranceContestManager.Gateways.Persistence
{
    public class EcmDbContext : DbContext
    {
        public EcmDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<ContestStore> Contests { get; set; }

        public DbSet<TrialStore> Trials { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder
                .Entity<TrialStore>()
                .HasOne(x => x.Contest)
                .WithMany(x => x.Trials)
                .HasForeignKey(x => x.ContestId);

            base.OnModelCreating(builder);
        }
    }
}
