#define Laptop
using DB_course.Models;
using DB_course.Models.DBModels;
using DB_course.Repositories;
using DB_course.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DB_course.Presenter
{
    public class UnLoginPresenter 
    {
        IUnLoginView view;
        AUnLoginModel model;

        IConnection connection;

        IConfigurationRoot config;
        ILoggerFactory loggerFactory = null;

        string login, password;
        public UnLoginPresenter(IView view, IConfigurationRoot config)
        {
            this.view = (IUnLoginView)view;

            this.view.SaveEvent += CheckPerson;

            this.config = config;

            connection = ConnectionBuilder.CreateMSSQLconnection(config);
            this.model = new UnLoginModel(new UnitOfWork(new SQLRepositoryAbstractFabric(connection)));

            this.view.Show();
        }

        public UnLoginPresenter(IView view, IConfigurationRoot config, ILoggerFactory loggerFactory)
        {
            this.view = (IUnLoginView)view;
            this.view.SaveEvent += CheckPerson;

            this.config = config;
            this.loggerFactory = loggerFactory;

            connection = ConnectionBuilder.CreateMSSQLconnection(config);
            this.model = new UnLoginModel(new UnitOfWork(new SQLRepositoryAbstractFabric(connection)));
            model = new UnLoginModelLogDecorator(model, loggerFactory);

            this.view.Show();
        }

        private void CheckPerson(object? sender, EventArgs e)
        {
            login = this.view.WorkerLogin;
            password = this.view.WorkerPassword;
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

          //  this.view.Close();

        }

        private void ShowHrView()
        {
            IHRAdminView view = HRAdminForm.GetInstace();
            connection = ConnectionBuilder.CreateMSSQLconnection(config, login, password);
            AHRAdminModel model = new HRAdminModel(new UnitOfWork(new SQLRepositoryAbstractFabric(connection)));
            if(loggerFactory != null)
                model = new HRAdminModelDecorator(model, loggerFactory);
            new HRAdminPresenter(view, model);
        }

        private void ShowWorkerView(string login)
        {
            IWorkerView view = WorkerForm.GetInstace();
            connection = ConnectionBuilder.CreateMSSQLconnection(config, login, password);
            AWorkerModel model = new WorkerModel(new UnitOfWork(new SQLRepositoryAbstractFabric(connection)), login);
            if(loggerFactory != null)
                model = new WorkerModelDecorator(model, loggerFactory);
            new WorkerPresenter(view, model);
        }
        private void ShowAdmin()
        {
            IWarehouseAdminView view = WarehouseAdminForm.GetInstace();
            connection = ConnectionBuilder.CreateMSSQLconnection(config, login, password);
            AWarehouseAdminModel model = new WarehouseAdminModel(new UnitOfWork(new SQLRepositoryAbstractFabric(connection)));
            if(loggerFactory != null)
                model = new WarehouseAdminModelDecorator(model, loggerFactory);
            new WarehouseAdminPresenter(view, model);
        }
    }
}
