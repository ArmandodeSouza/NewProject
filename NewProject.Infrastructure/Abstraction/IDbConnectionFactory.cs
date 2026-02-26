using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewProject.Infrastructure.Abstraction
{
    public interface IDbConnectionFactory
    {
        Task<NpgsqlConnection> CreateConnectionAsync();
    }
}
