using DB_course.Models.DBModels;
using DB_course.Models;
using DB_course.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_course.Models.CompositModels;
using Microsoft.Extensions.Logging;

namespace DB_course.tecknologicalUI
{
    public class WorkerConsole
    {
        private AWorkerModel model;
        private BindingSource productsBindingSource;
        private IEnumerable<WorkerLookCompose> productList;
        private BindingSource usingBindingSource;
        private IEnumerable<WorkerLookUsefulCompose> usingList;
        public WorkerConsole(IConnection connection, string login)
        {
            model = new WorkerModel(new UnitOfWork(new SQLRepositoryAbstractFabric(connection)), login);
            Menue();
        }
        public WorkerConsole(IConnection connection, string login, ILoggerFactory loggerFactory)
        {
            model = new WorkerModel(new UnitOfWork(new SQLRepositoryAbstractFabric(connection)), login);
            model = new WorkerModelDecorator(model, loggerFactory);
            Menue();
        }

        void Menue()
        {
            string state = "";
            while(state != "5")
            {
                Console.WriteLine("1 - AddUseful");
                Console.WriteLine("2 - RemoveUseful");
                Console.WriteLine("3 - LookProducts");
                Console.WriteLine("4 - LookUseful");
                Console.WriteLine("5 - Exit");
                Console.Write("Choose option: ");
                state = Console.ReadLine();
                switch(state)
                {
                    case "1":
                        Action(AddUseful);
                        break;
                    case "2":
                        Action(RemoveUseful);
                        break;
                    case "3":
                        Action(LookProducts);
                        break;
                    case "4":
                        Action(LookUseful);
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

        void LookUseful()
        {
            usingList = model.LookUsing();
            Console.WriteLine();
            Console.WriteLine($"{"Inventory",-10}|" + $"{"Name",-10}|" + $"{"Datecome",-10}|" + $"{"Dateproduct",-18}|");
            foreach(WorkerLookUsefulCompose p in usingList)
                Console.WriteLine($"{p.Inventory_number,-10}|" + $"{p.Name,-10}|" + $"{p.DateCome,-10}|" + $"{p.DateProduction,-18}|");
            Console.WriteLine();
        }

        void LookProducts()
        {
            productList = model.LookProducts();
            Console.WriteLine();
            Console.WriteLine($"{"Inventory",-10}|" + $"{"Name",-10}|" + $"{"Datecome",-10}|" + $"{"Dateproduct",-18}|");
            foreach(WorkerLookCompose p in productList)
                Console.WriteLine($"{p.Inventory_number,-10}|" + $"{p.Name,-10}|" + $"{p.DateCome,-10}|" + $"{p.DateProduction,-18}|");
            Console.WriteLine();
        }

        void AddUseful()
        {
            Console.Write("Input inventory number of product: ");
            model.AddUseful(model.LookProducts(Console.ReadLine()).First());
        }

        void RemoveUseful()
        {
            Console.Write("Input inventory number of product: ");
            model.DelitUseful(Convert.ToInt32(Console.ReadLine()));
        }

    }
}
