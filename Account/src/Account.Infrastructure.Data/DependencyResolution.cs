using Account.Domain.IRepository;
using Account.Infrastructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Infrastructure.Data
{
    public static class DependencyResolution
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDbManager, DbManager>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
