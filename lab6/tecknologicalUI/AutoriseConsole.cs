#define Laptop
using DB_course.Models;
using DB_course.Models.DBModels;
using DB_course.Presenter;
using DB_course.Repositories;
using DB_course.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DB_course.tecknologicalUI
{
    public class AutoriseConsole
    {
        AUnLoginModel model;
        private readonly string sqlConnectionString;
        IConfigurationRoot config;
        IConnection connection;
        ILoggerFactory loggerFactory =null;

        string login, password;
        public AutoriseConsole(IConfigurationRoot config)
          {
            this.config = config;

            string connectionString = "";
#if Laptop
            connectionString = config.GetConnectionString("MSSQL:unlogin:LaptopConnection") ?? throw new Exception();
#else
            connectionString = config.GetConnectionString("unlogin:DesktopConnection") ?? throw new Exception();
#endif
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;
            IConnection connection = new WarehouseContext(options);
            this.model = new UnLoginModel(new UnitOfWork(new SQLRepositoryAbstractFabric(connection)));
            CheckPerson();
        }
        public AutoriseConsole(IConfigurationRoot config, ILoggerFactory loggerFactory)
        {
            this.config = config;
            this.loggerFactory = loggerFactory;

            string connectionString = "";
#if Laptop
            connectionString = config.GetConnectionString("MSSQL:unlogin:LaptopConnection") ?? throw new Exception();
#else
            connectionString = config.GetConnectionString("unlogin:DesktopConnection") ?? throw new Exception();
#endif
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;
            IConnection connection = new WarehouseContext(options);
            this.model = new UnLoginModel(new UnitOfWork(new SQLRepositoryAbstractFabric(connection)));
            model = new UnLoginModelLogDecorator(model, loggerFactory);

            CheckPerson();
        }

        private void CheckPerson()
        {
            Console.Write("Input Login: ");
            login = Console.ReadLine();
            Console.Write("Input password: ");
            password = Console.ReadLine();
            State a = State.INVALID;
            try
            {
                 a = model.Check(login, password);
            }
            catch { }
            if(a == State.OK || a == State.FIRST)
                switch(model.Proffesion)
                {
                    case "worker":
                        ShowWorkerView(login);
                        break;
                    case "warehouseman":
                        break;
                    case "admin":
                        ShowAdmin();
                        break;
                    case "hradmin":
                        ShowHrView();
                        break;
                }

        }

        private void ShowHrView()
        {
            string connectionString = "";
#if Laptop
            connectionString = config.GetConnectionString("MSSQL:unlogin:LaptopConnection") ?? throw new Exception();
#else
            connectionString = config.GetConnectionString("unlogin:DesktopConnection") ?? throw new Exception();
#endif
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();

            var ConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
            ConnectionStringBuilder.UserID = login;
            ConnectionStringBuilder.Password = password;

            var options = optionsBuilder.UseSqlServer(ConnectionStringBuilder.ConnectionString).Options;
            IConnection connection = new WarehouseContext(options);
            if(loggerFactory==null)
            new HRAdminConsole(connection);
            else
            new HRAdminConsole(connection, loggerFactory);
        }

        private void ShowWorkerView(string login)
        {
            if (loggerFactory == null)
                new WorkerConsole(connection, login);
            else
                new WorkerConsole(connection, login, loggerFactory);    
        }
        private void ShowAdmin()
        {
            string connectionString = "";
#if Laptop
            connectionString = config.GetConnectionString("MSSQL:unlogin:LaptopConnection") ?? throw new Exception();
#else
            connectionString = config.GetConnectionString("unlogin:DesktopConnection") ?? throw new Exception();
#endif
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();

            var ConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
            ConnectionStringBuilder.UserID = login;
            ConnectionStringBuilder.Password = password;

            var options = optionsBuilder.UseSqlServer(ConnectionStringBuilder.ConnectionString).Options;
            IConnection connection = new WarehouseContext(options);
            if (loggerFactory == null)
                new WarehouseAdminConsole(connection);
            else
                new WarehouseAdminConsole(connection, loggerFactory);   
        }
    }
}
