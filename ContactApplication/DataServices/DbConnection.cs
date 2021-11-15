using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApi.DataServices
{
    public class DbConnection
    {
        
        private SqlConnection _sqlCon;
        public static IConfiguration _configuration;

        public SqlConnection GetConnection
        {
            get { return _sqlCon; }
            set { _sqlCon = value; }
        }
        public static IConfiguration Configuration  {
            get { return _configuration; }
            set { _configuration = value; } }
        public DbConnection()
        {

            string ConnectionString = Configuration.GetSection("AppSettings:ConStr").Value;
            _sqlCon = new SqlConnection(ConnectionString);
        }
    }
}
