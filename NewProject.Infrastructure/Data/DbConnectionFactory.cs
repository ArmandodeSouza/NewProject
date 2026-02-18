using NewProject.Infrastructure.Abstraction;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Infrastructure.Data {
    public class DbConnectionFactory : IDbConnectionFactory {
        private readonly string _connectionString;

        public DbConnectionFactory(string connectionString) {
            _connectionString = connectionString;
        }

        public NpgsqlConnection CreateConnection() {
            var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
