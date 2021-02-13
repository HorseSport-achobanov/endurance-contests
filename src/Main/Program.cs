using AutoMapper;
using Main.Database;
using Main.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Reflection;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = ConfigureServices();

            var dbService = provider.GetService<DbService>();

            var contest = new Contest(0, "Contest");
            var trial = new Trial(0, 10);

            contest.AddTrial(trial);

            dbService.Save(contest);

            var contestWithTrial = dbService.Get();
            var secondTrial = new Trial(0, 20);
            contestWithTrial.AddTrial(secondTrial);

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
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services.BuildServiceProvider();
        }
    }
}
