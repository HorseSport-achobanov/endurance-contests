﻿using EnduranceContestManager.Gateways.Persistence;
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

            var dbService = provider.GetService<DbService>();

            var contest = new ContestStore(0, "Contest");
            var trial = new TrialStore(0, 10, 0);

            contest.Trials.Add(trial);

            dbService.Save(contest);

            var contestWithTrial = dbService.Get();
            var secondTrial = new TrialStore(0, 20, 0);
            contestWithTrial.Trials.Add(secondTrial);

            dbService.Save(contestWithTrial);

            var result = dbService.Get();
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

            services.AddTransient<DbService, DbService>();

            return services.BuildServiceProvider();
        }
    }
}
