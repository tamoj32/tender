using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.IRepository;
using Infrastructue.Data.Repository;

namespace Infrastructue.Data
{
    public static class DependencyResolution
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDbManager, DbManager>();
            services.AddScoped<ITenderRepository, TenderRepository>();
        }
    }
}
