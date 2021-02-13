using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Main.Database
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
