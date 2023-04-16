using DB_course.Models.CompositModels;
using DB_course.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Repositories.CompositRepository
{
    internal class WorkerLookComposeRepository : ISQLRepository<WorkerLookCompose>
    {
        private WarehouseContext db;

        public IConnection DB { set { db = (WarehouseContext)value; } }

        public WorkerLookComposeRepository(IConnection db)
        {
            this.db = (WarehouseContext)db;
        }

        public void Create(WorkerLookCompose item)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<WorkerLookCompose> Get(string value)
        {
            var petList = new List<Person>();
            int petId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string petName = value;

            var D = (from I in db.InventoryProducts
                     join PR in db.Products on I.ProductId equals PR.Id
                     where I.InventoryNumber == petId || value.Equals(PR.Name)
                     select new WorkerLookCompose
                     {
               
                         Inventory_number = (int)I.InventoryNumber,
                         Name = PR.Name,
                         DateCome = PR.DateCome,
                         DateProduction = PR.DateProduction
                     });
            var K = from U in db.Usefuls select U.InventoryId;
            var A = from D1 in D
                    where !K.Contains(D1.Inventory_number)
                    select new WorkerLookCompose
                    {
                        Inventory_number = (int)D1.Inventory_number,
                        Name = D1.Name,
                        DateCome = D1.DateCome,
                        DateProduction = D1.DateProduction
                    };

            return A.ToList();
        }

        public IEnumerable<WorkerLookCompose> GetList()
        {
            var D = (from I in db.InventoryProducts
                    join PR in db.Products on I.ProductId equals PR.Id select new WorkerLookCompose
                    {
                        Inventory_number = (int)I.InventoryNumber,
                        Name = PR.Name,
                        DateCome = PR.DateCome,
                        DateProduction = PR.DateProduction
                    });
            var K = from U in db.Usefuls select U.InventoryId;
            var A = from D1 in D
                    where !K.Contains(D1.Inventory_number)
                    select new WorkerLookCompose
                    {
        
                        Inventory_number = (int)D1.Inventory_number,
                        Name = D1.Name,
                        DateCome = D1.DateCome,
                        DateProduction = D1.DateProduction
                    };

            return A.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(WorkerLookCompose item)
        {
            throw new NotImplementedException();
        }

        private bool disposed = false;



        public virtual void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                    db.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
