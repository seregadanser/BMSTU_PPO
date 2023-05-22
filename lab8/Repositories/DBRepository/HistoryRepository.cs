using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Repositories.DBRepository
{
    public class HistoryRepository : ISQLRepository<History>
    {

        private WarehouseContext db;

        public IConnection DB { set { db = (WarehouseContext)value; } }

        public HistoryRepository(IConnection db)
        {
            this.db = (WarehouseContext)db;
        }

        public void Create(History item)
        {
            db.Historys.Add(item);
        }

        public void Delete(string key)
        {
            int id = 0;
            try
            {
                id = Convert.ToInt32(key);
            }
            catch { throw new Exception("unvalid key"); }
            History book = db.Historys.Find(id);
            if (book != null)
                db.Historys.Remove(book);
        }


        public IEnumerable<History> Get(string value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<History> GetList()
        {
            return db.Historys.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(History item)
        {
            throw new NotImplementedException();
        }
        private bool disposed = false;



        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
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
