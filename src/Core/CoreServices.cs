﻿using AutoMapper;
using EnduranceContestManager.Core.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;

namespace EnduranceContestManager.Core
{
    public static class CoreServices
    {
        public static IServiceCollection AddCore(this IServiceCollection services, params Assembly[] assemblies)
            => services
                .AddConventionalServices(assemblies)
                .AddMapping(assemblies);

        private static IServiceCollection AddMapping(
            this IServiceCollection services,
            IEnumerable<Assembly> assemblies)
            => services.AddAutoMapper(assemblies);
    }
}
