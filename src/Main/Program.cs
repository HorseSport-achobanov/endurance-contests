using EnduranceContestManager.Gateways.Persistence;
using EnduranceContestManager.Gateways.Persistence.Stores;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Linq;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = ConfigureServices();

            var dbContext = provider.GetService<EcmDbContext>();

            var contest = new ContestStore(0, "Contest");
            var trial = new TrialStore(0, 10, 0);

            contest.Trials.Add(trial);

            dbContext.Contests.Add(contest);
            dbContext.SaveChanges();

            var contestWithTrial = dbContext
                .Contests
                .Include(x => x.Trials)
                .First();

            var secondTrial = new TrialStore(0, 20, 0);

            contestWithTrial.Trials.Add(secondTrial);

            dbContext.SaveChanges();
            ;
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services
                .AddDbContext<EcmDbContext>(options =>
                    options
                        .UseInMemoryDatabase(Guid.NewGuid().ToString())
                        .EnableSensitiveDataLogging()
                        .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)));

            return services.BuildServiceProvider();
        }
    }
}
