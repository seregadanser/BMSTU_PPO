using DB_course.Models;
using DB_course.Models.DBModels;
using DB_course.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;


namespace DB_course.tecknologicalUI
{
    public class HRAdminConsole
    {
        private AHRAdminModel model;
        private BindingSource workersBindingSource;
        private IEnumerable<Person> personList;
        public HRAdminConsole(IConnection connection)
        {
            model = new HRAdminModel(new UnitOfWork(new SQLRepositoryAbstractFabric(connection)));
            Menue();
        }
        public HRAdminConsole(IConnection connection, ILoggerFactory loggerFactory)
        {
            model = new HRAdminModel(new UnitOfWork(new SQLRepositoryAbstractFabric(connection)));
            model = new HRAdminModelDecorator(model, loggerFactory);
            Menue();
        }

        void Menue()
        {
            string state = "";
            while(state != "5")
            {
                Console.WriteLine("1 - AddPerson");
                Console.WriteLine("2 - RemovePerson");
                Console.WriteLine("3 - UpdatePerson");
                Console.WriteLine("4 - LookList");
                Console.WriteLine("5 - Exit");
                Console.Write("Choose option: ");
                state = Console.ReadLine();
                switch(state)
                {
                    case "1":
                        Action(AddPerson);
                        break;
                    case "2":
                        Action(RemovePerson);
                        break;
                    case "3":
                        Action(UpdatePerson);
                        break;
                    case "4":
                        Action(LookPerson);
                        break;
                }
            }
        }
        delegate void ActDel();
        void Action(ActDel a)
        {
            try
            {
                a.Invoke();
            }
            catch(Exception ex)
            { Console.WriteLine(ex.Message); }
        }

        void LookPerson()
        {
            personList = model.LookPerson();
            Console.WriteLine();
            Console.WriteLine($"{"Login",-10}|" + $"{"Name",-10}|" + $"{"Sername",-10}|" + $"{"Birthday",-18}|" + $"{"Position",-8}|");
            foreach(Person p in personList)
            {
                Console.WriteLine($"{p.Login, -10}|" + $"{p.Name,-10}|"+ $"{p.SecondName,-10}|"+$"{p.DateOfBirthday,-18}|"+$"{p.Position, -8}|");
            }
            Console.WriteLine();
        }

        void AddPerson()
        {
            var person = new Person();
            Console.Write("Input Name: ");
            person.Name = Console.ReadLine();
            Console.Write("Input second name: ");
            person.SecondName = Console.ReadLine();
            Console.Write("Input position: ");
            person.Position = Console.ReadLine();
            Console.Write("Input date of birthday: ");
            person.DateOfBirthday = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            Console.Write("Input login: ");
            person.Login = Console.ReadLine();
            Console.Write("Input password: ");
            person.Password = Hash.HashFunc(Console.ReadLine());
            person.NumberOfCome = 0;
            model.AddPerson(person);
            Console.WriteLine("Add sucesfull");
        }

        void RemovePerson()
        {
            Console.Write("Input login: ");
            model.RemovePerson(Console.ReadLine());
        }

        void UpdatePerson()
        {
            Console.Write("Input login of update person: ");
            string cur = Console.ReadLine();
            var person = new Person();
            Console.Write("Input Name: ");
            person.Name = Console.ReadLine();
            Console.Write("Input second name: ");
            person.SecondName = Console.ReadLine();
            Console.Write("Input position: ");
            person.Position = Console.ReadLine();
            Console.Write("Input date of birthday: ");
            person.DateOfBirthday = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            model.UpdatePerson(cur,person);
        }
    }
}
