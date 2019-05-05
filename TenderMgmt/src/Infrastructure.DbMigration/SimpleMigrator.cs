using Microsoft.Extensions.Configuration;
using SimpleMigrations;
using SimpleMigrations.DatabaseProvider;
using System;
using System.Data.SqlClient;
using System.Reflection;

namespace Infrastructure.DbMigration
{
    public interface ISimpleMigration
    {
        void Run(string[] args);
    }

    public class SimpleMigration : ISimpleMigration
    {
        public SimpleMigration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; set; }

        public void Run(string[] args)
        {
            var migrationsAssembly = typeof(Program).GetTypeInfo().Assembly;
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            using (var connection = new SqlConnection(connectionString))
            {
                var databaseProvider = new MssqlDatabaseProvider(connection);
                var migrator = new SimpleMigrator(migrationsAssembly, databaseProvider);
                migrator.Load();
                migrator.MigrateToLatest();
            }
        }
    }
}
