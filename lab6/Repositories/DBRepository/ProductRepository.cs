using DB_course.Models.DBModels;
using DB_course.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Repositories.DBRepository
{
    public class ProductRepository : ISQLRepository<Product>
    {
        private WarehouseContext db;

        public IConnection DB { set { db = (WarehouseContext)value; } }

        public ProductRepository(IConnection db)
        {
            this.db = (WarehouseContext)db;
        }


        public void Create(Product item)
        {
            try
            {
                db.Products.Add(item);
            }
            catch  (Exception ex)
            {
                db.ChangeTracker.Clear();
                throw ex;
            }
        }

        public void Delete(string key)
        {
            Product book = db.Products.Find(Convert.ToInt32(key));
            if(book == null)
                throw new Exception("product not Exists");
            db.Products.Remove(book);
        }



        public IEnumerable<Product> Get(string value)
        {
            var petList = new List<Person>();
            int petId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string petName = value;

            return (from user in db.Products
                    where petId == user.Id
                    select user).ToList();

        }

        public IEnumerable<Product> GetList()
        {
            return db.Products.ToList();
        }

   

        public void Update(Product item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public void Save()
        {
            try
            {
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                db.ChangeTracker.Clear();
                throw ex;
            }
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
