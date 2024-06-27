using Microsoft.Extensions.DependencyInjection;
using Netrunner.Application.ClassicExample.Contract;
using Netrunner.Application.ClassicExample.Implementaion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netrunner.Application
{
    public static class Startup
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICardLogic, CardLogic>();

                return services;
        }
    }
}
