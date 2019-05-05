using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DbMigration
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }

        private IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(opt =>
            {
                opt.AddConsole();
            });
            services.AddSingleton<IConfigurationRoot>(Configuration);
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddSingleton<ISimpleMigration, SimpleMigration>();
        }
    }
}
