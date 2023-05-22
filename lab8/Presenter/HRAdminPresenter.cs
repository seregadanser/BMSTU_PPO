using DB_course.Models;
using DB_course.Models.DBModels;
using DB_course.Repositories;
using DB_course.View;
using Microsoft.Data.SqlClient;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace DB_course.Presenter
{
    public class HRAdminPresenter
    {
        private IHRAdminView view;
        private AHRAdminModel model;
        private BindingSource workersBindingSource;
        private IEnumerable<Person> personList;

        public HRAdminPresenter(IHRAdminView view, IModel model)
        {
            this.workersBindingSource = new BindingSource();
            this.view = view;
            this.model = (AHRAdminModel)model;

            this.view.SearchEvent += SearchWorker;
            this.view.AddNewEvent += AddNewWorker;
            this.view.EditEvent += LoadSelectedWorkerToEdit;
            this.view.DeleteEvent += DeleteSelectedWorker;
            this.view.SaveEvent += SaveWorker;
            this.view.CancelEvent += CancelAction;

            this.view.SetWorkerListBindingSource(workersBindingSource);

            LoadAllWorkerList();

            this.view.Show();
        }
        //Methods
        private void LoadAllWorkerList()
        {
            personList = model.LookPerson();
            workersBindingSource.DataSource = personList;
        }
        private void SearchWorker(object sender, EventArgs e)
        {
            personList = model.LookPerson(view.SearchValue);
            workersBindingSource.DataSource = personList;
            
        }
        private void CancelAction(object sender, EventArgs e)
        {
            view.WorkerSecondName = "";
            view.WorkerPosition = "";
            view.WorkerName = "";
            view.WorkerBirthday = "";
        }
        private void SaveWorker(object sender, EventArgs e)
        {
            try
            {
                var person = new Person();
                person.Name = view.WorkerName;
                person.SecondName = view.WorkerSecondName;
                person.Position = view.WorkerPosition;              
                person.DateOfBirthday = DateTime.ParseExact(view.WorkerBirthday, "dd.MM.yyyy", CultureInfo.InvariantCulture);


                if (view.IsEdit)
                {
                    person.Login = log;
                    person.Password = pass;
                    person.NumberOfCome = count;
                    model.UpdatePerson(log, person);
                    view.Message = "worker edited successfuly";
                }
                else
                {
                    person.Login = view.WorkerLogin;
                    person.Password = Hash.HashFunc(view.WorkerPassword);
                    person.NumberOfCome = 0;
                    model.AddPerson(person);
                    view.Message = "worker added sucessfully";
                }
 
                view.IsSuccessful = true;
                personList = model.LookPerson();
                workersBindingSource.DataSource = personList;

                view.WorkerSecondName = "";
                view.WorkerPosition = "";
                view.WorkerName = "";
                view.WorkerBirthday = "";
                view.WorkerLogin = "";
                view.WorkerPassword = "";
                view.WorkerLogin = "";
                
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }
        private void DeleteSelectedWorker(object sender, EventArgs e)
        {
            try
            {
                var worker = (Person)workersBindingSource.Current;
                if (worker == null) throw new Exception("Cant delit empty person");
                model.RemovePerson(worker.Login);
                view.IsSuccessful = true;
                view.Message = "worker deleted successfully";
                personList = model.LookPerson();
                workersBindingSource.DataSource = personList;
               
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }
        private string pass = "", log= "";
        private int count = 0;
        private void LoadSelectedWorkerToEdit(object sender, EventArgs e)
        {
            try
            {
                Person worker = (Person)workersBindingSource.Current ?? throw new Exception();

                view.WorkerName = worker.Name;
                view.WorkerSecondName = worker.SecondName;
                view.WorkerPosition = worker.Position;
                view.WorkerBirthday = worker.DateOfBirthday.ToString();

                log= worker.Login;
                pass = worker.Password;
                count = (int)worker.NumberOfCome;

                view.IsEdit = true;
                view.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = "An error ocurred, could not edit worker";
            }
        }
        private void AddNewWorker(object sender, EventArgs e)
        {
             view.IsEdit = false;
        }
    }
}
