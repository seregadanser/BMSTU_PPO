#define Laptop
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_course.Models.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Neo4jClient;
using Neo4jClient.Execution;

namespace DB_course.Models
{
    public interface IConnection
    {
        public string Type { get; set; }
    }

    public class N4jGrafClient : GraphClient, IConnection
    {
        public N4jGrafClient(Uri rootUri, IHttpClient httpClient) : base(rootUri, httpClient)
        {
        }
        public N4jGrafClient(string rootUri, string username = null, string password = null) : base(rootUri, username, password)
        {
        }

        public string Type { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
