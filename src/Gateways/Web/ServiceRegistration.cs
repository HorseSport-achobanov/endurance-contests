﻿using Blog.Common.ConventionalServices;
using Blog.Gateways.Web.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Gateways.Web
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddWebComponents(
            this IServiceCollection services)
            => services
                .AddHttpContextAccessor()
                .AddConventionalServices(typeof(ServiceRegistration).Assembly)
                .AddContractProviders(typeof(AuthenticationProvider).Assembly);
    }
}
