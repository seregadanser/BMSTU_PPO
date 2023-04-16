using DB_course.Models.CompositModels;
using DB_course.Models.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Repositories.CompositRepository
{
    public class WarehousemanLookComposeRepository : ISQLRepository<WarehousemanLookCompose>
    {
        private WarehouseContext db;

        public IConnection DB { set { db = (WarehouseContext)value; } }

        public WarehousemanLookComposeRepository(IConnection db)
        {
            this.db = (WarehouseContext)db;
        }

        public void Create(WarehousemanLookCompose item)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<WarehousemanLookCompose> Get(string value)
        {
            var petList = new List<Person>();
            int petId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string petName = value;

            var N = from PO in db.PlaceofObjects
                    join P in db.Places on PO.PlaceId equals P.Id
                    select new { PO.InventoryId, P.NumberStay, P.NumberLayer };

            var WLC = from U in db.Usefuls
                      join PE in db.Persons on U.PersonId equals PE.Login
                      join NT in N on U.InventoryId equals NT.InventoryId
                      join I in db.InventoryProducts on U.InventoryId equals I.InventoryNumber
                      where I.InventoryNumber == petId || EF.Functions.Like(PE.Name!, value) || EF.Functions.Like(PE.SecondName!, value)
                      select new WarehousemanLookCompose
                      {
                   
                          Name = PE.Name,
                          SecondName = PE.SecondName,
                          Login = PE.Login,
                          InventoryNumber = I.InventoryNumber,
                          NumberStay = NT.NumberStay,
                          NumberLayer = Convert.ToString(NT.NumberLayer),
                          DateOfStart = U.DateOfStart
                      };
            return WLC.ToList();

        }

        public IEnumerable<WarehousemanLookCompose> GetList()
        {
            var N = from PO in db.PlaceofObjects join P in db.Places on PO.PlaceId equals P.Id 
            select new { PO.InventoryId, P.NumberStay, P.NumberLayer };

            var WLC = from U in db.Usefuls
                      join PE in db.Persons on U.PersonId equals PE.Login
                      join NT in N on U.InventoryId equals NT.InventoryId
                      join I in db.InventoryProducts on U.InventoryId equals I.InventoryNumber
                      select new WarehousemanLookCompose
                      {
                          InventoryNumber = U.InventoryId,
                          Name = PE.Name,
                          SecondName = PE.SecondName,
                          Login = PE.Login,
                          NumberStay = NT.NumberStay,
                          NumberLayer = Convert.ToString(NT.NumberLayer),
                          DateOfStart = U.DateOfStart
                      };
            var groupedResult = WLC.GroupBy(a => a.Login);
            var result = groupedResult.ToList().Select(eg => new WarehousemanLookCompose
            {
                Login = eg.Key,
                Name = eg.First().Name,
                SecondName = eg.First().SecondName,
                InventoryNumber = eg.First().InventoryNumber,
                DateOfStart = eg.First().DateOfStart,
                NumberStay = eg.First().NumberStay,
                NumberLayer = string.Join(",", eg.Select(i => i.NumberLayer))
            });
            return result.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(WarehousemanLookCompose item)
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
