using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Infrastructue.Data
{
    public interface IDbManager
    {
        IDbConnection Connection { get; }

        void Dispose();
    }

    public class DbManager : IDbManager
    {
        private ILogger _logger { get; set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="DbManager" /> class.
        /// </summary>
        /// <param name="configuration">The name of the connection string</param>
        public DbManager(IConfiguration configuration, ILogger<DbManager> logger)
        {
            _logger = logger;
            string connString = configuration.GetConnectionString("DefaultConnection");

            _logger.LogInformation($"Connection String: {connString}");

            Conn = new SqlConnection(connString);
        }

        /// <summary>
        /// Return open connection
        /// </summary>
        public IDbConnection Connection
        {
            get
            {
                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                }

                return Conn;
            }
        }

        private IDbConnection Conn { get; set; }

        /// <summary>
        /// Close and dispose of the database connection
        /// </summary>
        public void Dispose()
        {
            if (Conn == null)
            {
                return;
            }

            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
                Conn.Dispose();
            }

            Conn = null;
        }
    }
}
