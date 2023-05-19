#define Laptop
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_course.Models.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace DB_course.Models
{
    public interface IConnection
    {
        public string Type { get; set; }
    }

    public static class ConnectionBuilder
    {


        public static IConnection CreateMSSQLconnection(IConfigurationRoot config)
        {
            string connectionString = "";
            connectionString = config.GetConnectionString("Connection") ?? throw new Exception();
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;
            IConnection connection = new WarehouseContext(options);
            return connection;
        }

        public static IConnection CreateMSSQLconnection(IConfigurationRoot config, string login, string password)
        {
            string connectionString = "";
            connectionString = config.GetConnectionString("Connection") ?? throw new Exception();

            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();

            var ConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
            ConnectionStringBuilder.UserID = login;
            ConnectionStringBuilder.Password = password;

            var options = optionsBuilder.UseSqlServer(ConnectionStringBuilder.ConnectionString).Options;
            IConnection connection = new WarehouseContext(options);
            return connection;
        }
    }
}
