using DB_course.Models.CompositModels;
using DB_course.Models.DBModels;
using Microsoft.EntityFrameworkCore;
using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Repositories.CompositRepository
{
    internal class WorkerLookUsefulComposeRepositoryN : INeo4jRepository<WorkerLookUsefulCompose>
    {
        private readonly N4jGrafClient _graphClient;

        public IConnection DB { set { } }

        public WorkerLookUsefulComposeRepositoryN(IConnection graphClient)
        {
            _graphClient = (N4jGrafClient)graphClient;
        }

        public IEnumerable<WorkerLookUsefulCompose> GetList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WorkerLookUsefulCompose> Get(string value)
        {
            var query = _graphClient.Cypher
             .Match("(i:InventoryProduct)-[:HAS_PRODUCT]->(p:Product)")
             .Where((Useful u) => u.PersonId == value)
             .Return((i, p, u) => new WorkerLookUsefulCompose
             {
                 Inventory_number = i.As<InventoryProduct>().InventoryNumber,
                 Name = p.As<Product>().Name,
                 DateCome = p.As<Product>().DateCome,
                 DateProduction = p.As<Product>().DateProduction,
                 DateOfStart = u.As<Useful>().DateOfStart
             });

            return query.ResultsAsync.Result;
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
          
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
           
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
