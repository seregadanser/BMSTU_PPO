using DB_course.Models.CompositModels;
using DB_course.Models.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Repositories.CompositRepository
{
    internal class WorkerLookUsefulComposeRepository : ISQLRepository<WorkerLookUsefulCompose>
    {
        private WarehouseContext db;

        public IConnection DB { set { db = (WarehouseContext)value; } }

        public WorkerLookUsefulComposeRepository(IConnection db)
        {
            this.db = (WarehouseContext)db;
        }

        public IEnumerable<WorkerLookUsefulCompose> GetList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkerLookUsefulCompose> Get(string value)
        {
            var D = from I in db.InventoryProducts
                    join P in db.Products on I.ProductId equals P.Id
                    select new {I.InventoryNumber, P.Name, P.DateCome, P.DateProduction };

            var A = from D1 in D
                    join U in db.Usefuls on D1.InventoryNumber equals U.InventoryId
                    where EF.Functions.Like(U.PersonId!, value)
                    select new WorkerLookUsefulCompose
                    {
                        Inventory_number = (int)D1.InventoryNumber,
                        Name = D1.Name,
                        DateCome = D1.DateCome,
                        DateProduction = D1.DateProduction,
                        DateOfStart = U.DateOfStart
                    };
            return A.ToList();
        }

        public void Create(WorkerLookUsefulCompose item)
        {
            throw new NotImplementedException();
        }

        public void Update(WorkerLookUsefulCompose item)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            db.SaveChanges();
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
