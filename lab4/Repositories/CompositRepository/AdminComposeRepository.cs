using DB_course.Models.CompositModels;
using DB_course.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Repositories.CompositRepository
{
    public class AdminComposeRepository : ISQLRepository<AdminCompose>
    {
        private WarehouseContext db;

        public IConnection DB { set { db = (WarehouseContext)value; } }

        public AdminComposeRepository(IConnection db)
        {
            this.db = (WarehouseContext)db;
        }

        public void Create(AdminCompose item)
        {
            throw new NotImplementedException();
        }

        public void Delete(string key)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<AdminCompose> Get(string value)
        {
            var N = from IP in db.InventoryProducts
                    join P in db.PlaceofObjects on IP.InventoryNumber equals P.InventoryId
                    join PR in db.Products on IP.ProductId equals PR.Id
                    select new AdminCompose
                    {
                        ProductId = PR.Id,

                        Name = PR.Name,

                        DateCome = (DateTime)PR.DateCome,

                        DateProduction = (DateTime)PR.DateProduction,

                        InventoryNumber = IP.InventoryNumber,

                        value = (int)PR.Value,

                        PlaceId = Convert.ToString(P.PlaceId)
                    };


            var groupedResult = N.GroupBy(a => a.InventoryNumber);
            var result = groupedResult.ToList().Select(eg => new AdminCompose
            {

                ProductId = eg.First().ProductId,

                Name = eg.First().Name,

                DateCome = eg.First().DateCome,

                DateProduction = eg.First().DateProduction,

                InventoryNumber = eg.Key,

                value = eg.First().value,

                PlaceId = string.Join(",", eg.Select(i => i.PlaceId))

            });
            return result.ToList();
        }

        public IEnumerable<AdminCompose> GetList()
        {
            var N = from IP in db.InventoryProducts
                    join P in db.PlaceofObjects on IP.InventoryNumber equals P.InventoryId
                    join PR in db.Products on IP.ProductId equals PR.Id
                    select new AdminCompose
                    {
                        ProductId = PR.Id,
                        Name = PR.Name,
                        DateCome = (DateTime)PR.DateCome,
                        DateProduction = (DateTime)PR.DateProduction,
                        InventoryNumber = IP.InventoryNumber,
                        value = (int)PR.Value,
                        PlaceId = Convert.ToString(P.PlaceId),
                        PlaceOfObjectlId = Convert.ToString(P.Id)
                    };

           
            var groupedResult = N.GroupBy(a => a.InventoryNumber);
            var result = groupedResult.ToList().Select(eg => new AdminCompose
            {
                
                ProductId = eg.First().ProductId,

                Name = eg.First().Name,

                DateCome = eg.First().DateCome,

                DateProduction = eg.First().DateProduction,

                InventoryNumber = eg.Key,

                value = eg.First().value,

                PlaceId = string.Join(",", eg.Select(i => i.PlaceId)),
                PlaceOfObjectlId = string.Join(",", eg.Select(i => i.PlaceOfObjectlId)),

            });
            return result.ToList();
        }

        public void Update(AdminCompose item)
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
