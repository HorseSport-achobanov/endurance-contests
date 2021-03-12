﻿using EnduranceJudge.Application.Interfaces.Events;
using EnduranceJudge.Core.Interfaces;
using EnduranceJudge.Gateways.Persistence.Repositories.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EnduranceJudge.Gateways.Persistence.Startup
{
    public static class PersistenceServices
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDataProtection();

            return services
                .AddDatabase()
                .AddTransient<IEventsDataStore, EnduranceJudgeDbContext>()
                .AddRepositories()
                .AddSingleton<IInitializerInterface, PersistenceInitializer>();
        }

        private static IServiceCollection AddDatabase(this IServiceCollection services)
            => services
                .AddDbContext<EnduranceJudgeDbContext>(options =>
                    options
                        .UseInMemoryDatabase(Guid.NewGuid().ToString())
                        .EnableSensitiveDataLogging()
                        .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)));

        private static IServiceCollection AddRepositories(this IServiceCollection services)
            => services
                .AddTransient<IEventCommands, EventsRepository>()
                .AddTransient<IEventQueries, EventsRepository>();
    }
}