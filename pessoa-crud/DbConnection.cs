using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pessoa_crud {
    public interface IDbConnection {
        public SqlConnection GetConnection { get; }
    }
    public class DbConnection : IDbConnection {
        IConfiguration Configuration;

        public DbConnection(IConfiguration configuration) {
            Configuration = configuration;
        }

        public SqlConnection GetConnection {
            get {
                var connectionString = Configuration.GetConnectionString("AuthDbContextConnection");
                return new SqlConnection(connectionString);
            }
        }
    }
}
