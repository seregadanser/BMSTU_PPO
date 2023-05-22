using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_course.Models.CompositModels;
using DB_course.Models.DBModels;
using DB_course.Models;
using DB_course.Repositories;
using Microsoft.Extensions.Logging;

namespace DB_course.tecknologicalUI
{
    public class WarehousemanConsole
    {
        private AWarehousemanModel model;

        private IEnumerable<WarehousemanLookCompose> usingList;

        public WarehousemanConsole(IConnection connection)
        {
            model = new WarehousemanModel(new UnitOfWork(new SQLRepositoryAbstractFabric(connection)));
            Menue();
        }
        public WarehousemanConsole(IConnection connection, ILoggerFactory loggerFactory)
        {
            model = new WarehousemanModel(new UnitOfWork(new SQLRepositoryAbstractFabric(connection)));
            model = new WarehousemanModelLogDecorator(model, loggerFactory);
            Menue();
        }

        void Menue()
        {
            string state = "";
            while (state != "5")
            {
                Console.WriteLine("1 - RemoveUseful");
                Console.WriteLine("2 - LookUseful");
                Console.WriteLine("5 - Exit");
                Console.Write("Choose option: ");
                state = Console.ReadLine();
                switch (state)
                {
                    case "1":
                        Action(RemoveUseful);
                        break;
                    case "2":
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
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }

        void LookUseful()
        {
            usingList = model.LookWarehousemanLook();
            Console.WriteLine();
            Console.WriteLine($"{"Inventory",-10}|" + $"{"Name",-10}|" + $"{"NumberLayer",-10}|" + $"{"NumberSaty",-18}|");
            foreach (WarehousemanLookCompose p in usingList)
                Console.WriteLine($"{p.InventoryNumber,-10}|" + $"{p.Name,-10}|" + $"{p.NumberLayer,-10}|" + $"{p.NumberStay,-10}|");
            Console.WriteLine();
        }
        void RemoveUseful()
        {
            Console.Write("Input inventory number of product: ");
            model.DelitUseful(Convert.ToInt32(Console.ReadLine()));
        }
    }
}
