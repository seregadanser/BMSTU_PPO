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

namespace DB_course.tecknologicalUI
{
    public class AutoriseConsole
    {
        AUnLoginModel model;
        private readonly string sqlConnectionString;
        IConnection connection;

        public AutoriseConsole(string sqlConnectionString)
          {
            this.sqlConnectionString = sqlConnectionString;
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
            var options = optionsBuilder.UseSqlServer(sqlConnectionString).Options;
            connection = new WarehouseContext(options);

            this.model = new UnLoginModel(new UnitOfWork(new SQLRepositoryAbstractFabric(connection)));

            CheckPerson();
        }

        private void CheckPerson()
        {
            Console.Write("Input Login: ");
            string login = Console.ReadLine();
            Console.Write("Input password: ");
            string password = Console.ReadLine();

            State a = model.Check(login, password);  
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
            new HRAdminConsole(connection);
        }

        private void ShowWorkerView(string login)
        {
            new WorkerConsole(connection, login);
        }
        private void ShowAdmin()
        {
            new WarehouseAdminConsole(connection);
        }
    }
}
