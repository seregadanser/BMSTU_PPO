using DB_course.Models.CompositModels;
using DB_course.Models.DBModels;
using DB_course.Models;
using DB_course.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace DB_course.tecknologicalUI
{
    public class WarehouseAdminConsole
    {
        private WarehouseAdminModel model;
        private IEnumerable<AdminCompose> productList;
        private IEnumerable<Place> placesList;


        public WarehouseAdminConsole(IConnection connection)
        {
            model = new WarehouseAdminModel(new UnitOfWork(new SQLRepositoryAbstractFabric(connection)));
            Menue();
        }

        void Menue()
        {

            //this.view.DeleteEvent += DeleteSelectedProduct;
            //this.view.SaveEvent += AddNewProduct;


            string state = "";
            while(state != "8")
            {
                Console.WriteLine("1 - AddProduct");
                Console.WriteLine("2 - RemoveProduct");
                Console.WriteLine("3 - LookProducts");
                Console.WriteLine("4 - AddPlace");
                Console.WriteLine("5 - RemovePlace");
                Console.WriteLine("6 - UpdatePlace");
                Console.WriteLine("7 - LookPlaces ");
                Console.WriteLine("8 - Exit");
                Console.Write("Choose option: ");
                state = Console.ReadLine();
                switch(state)
                {
                    case "1":
                        Action(AddProduct);
                        break;
                    case "2":
                        Action(RemoveProduct);
                        break;
                    case "3":
                        Action(LookProducts);
                        break;
                    case "4":
                        Action(AddPlace);
                        break;
                    case "5":
                        Action(RemovePlace);
                        break;
                    case "6":
                        Action(UpdatePlace);
                        break;
                    case "7":
                        Action(LookPlaces);
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

        void LookProducts()
        {
            productList = model.GetProducts();
            Console.WriteLine();
            Console.WriteLine($"{"Inventory",-10}|" + $"{"Name",-10}|" + $"{"Datecome",-10}|" + $"{"Dateproduct",-18}|");
            foreach(AdminCompose p in productList)
                Console.WriteLine($"{p.ProductId,-10}|" + $"{p.Name,-10}|" + $"{p.DateCome,-10}|" + $"{p.DateProduction,-18}|" + $"{p.PlaceId,-18}|" + $"{p.InventoryNumber,-18}|");
            Console.WriteLine();
        }

        private void LookPlaces()
        {
            placesList = model.GetPlace();
            Console.WriteLine();
            Console.WriteLine($"{"Id",-10}|" + $"{"Lauer",-10}|" + $"{"Stay",-10}|" + $"{"Size",-10}|");
            foreach(Place p in placesList)
                Console.WriteLine($"{p.Id,-10}|" + $"{p.NumberLayer,-10}|" + $"{p.NumberStay,-10}|" + $"{p.Size,-10}|");
            Console.WriteLine();
        }

        void AddPlace()
        {
            var person = new Place();
            Console.Write("Input Id: ");
            string s = Console.ReadLine(); 
            person.Id = int.TryParse(s, out _) ? Convert.ToInt32(s) : throw new Exception("invalid id");
            Console.Write("Input layer: ");
            s = Console.ReadLine();
            person.NumberLayer = int.TryParse(s, out _) ? Convert.ToInt32(s) : throw new Exception("invalid layer");
            Console.Write("Input stay: ");
            s = Console.ReadLine();
            person.NumberStay = int.TryParse(s, out _) ? Convert.ToInt32(s) : throw new Exception("invalid stay");
            Console.Write("Input size: ");
            s = Console.ReadLine();
            person.Size = int.TryParse(s, out _) ? Convert.ToInt32(s) : throw new Exception("invalid size");
            model.AddPlace(person);
            Console.WriteLine("Add sucesfull");
        }

        void RemovePlace ()
        {
            Console.Write("Input id: ");
            string s = Console.ReadLine();
            int Id = int.TryParse(s, out _) ? Convert.ToInt32(s) : throw new Exception("invalid id");
            model.RemovePlace(Id);
        }

        void UpdatePlace()
        {
            Console.Write("Input id: ");
            string s = Console.ReadLine();
            int Id = int.TryParse(s, out _) ? Convert.ToInt32(s) : throw new Exception("invalid id");
            var person = new Place();
            Console.Write("Input layer: ");
            s = Console.ReadLine();
            person.NumberLayer = int.TryParse(s, out _) ? Convert.ToInt32(s) : throw new Exception("invalid layer");
            Console.Write("Input stay: ");
            s = Console.ReadLine();
            person.NumberStay = int.TryParse(s, out _) ? Convert.ToInt32(s) : throw new Exception("invalid stay");
            Console.Write("Input size: ");
            s = Console.ReadLine();
            person.Size = int.TryParse(s, out _) ? Convert.ToInt32(s) : throw new Exception("invalid size");
            model.UpdatePlace(Id, person);
        }

        void AddProduct()
        {
            var product = new AdminCompose();
            Console.Write("Input date come: ");
            product.DateCome = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            Console.Write("Input product id: ");
            string s = Console.ReadLine();
            product.ProductId = int.TryParse(s, out _) ? Convert.ToInt32(s) : throw new Exception("invalid id");
            Console.Write("Input places id: ");
            product.PlaceId = Console.ReadLine();
            Console.Write("Input inventory number: ");
            s = Console.ReadLine();
            product.InventoryNumber = int.TryParse(s, out _) ? Convert.ToInt32(s) : throw new Exception("invalid inventory");
            Console.Write("Input date production: ");
            product.DateProduction = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            Console.Write("Input product name: ");
            product.Name = Console.ReadLine();
            model.AddProduct(product);
        }

        void RemoveProduct()
        {
            Console.Write("Input inventory number: ");
            model.RemoveProduct(model.GetProducts(Console.ReadLine()).First());
        }
    }
}
