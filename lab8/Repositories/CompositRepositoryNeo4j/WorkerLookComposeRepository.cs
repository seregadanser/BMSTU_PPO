using DB_course.Models.CompositModels;
using DB_course.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Repositories.CompositRepository
{
    internal class WorkerLookComposeRepositoryN : INeo4jRepository<WorkerLookCompose>
    {
        private readonly N4jGrafClient _graphClient;

        public IConnection DB { set { } }

        public WorkerLookComposeRepositoryN(IConnection graphClient)
        {
            _graphClient = (N4jGrafClient)graphClient;
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
            int petId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;

            var query = _graphClient.Cypher
                .Match("(i:InventoryProduct)-[:HAS_PRODUCT]->(p:Product)")
                .Where((InventoryProduct i, Product p) => i.InventoryNumber == petId || p.Name == value)
                .Return((i, p) => new WorkerLookCompose
                {
                    Inventory_number = i.As<InventoryProduct>().InventoryNumber,
                    Name = p.As<Product>().Name,
                    DateCome = p.As<Product>().DateCome,
                    DateProduction = p.As<Product>().DateProduction
                });

            return query.ResultsAsync.Result;
        }

        public IEnumerable<WorkerLookCompose> GetList()
        {
            var query = _graphClient.Cypher
                .Match("(i:InventoryProduct)-[:HAS_PRODUCT]->(p:Product)")
                .Return((i, p) => new WorkerLookCompose
                {
                    Inventory_number = i.As<InventoryProduct>().InventoryNumber,
                    Name = p.As<Product>().Name,
                    DateCome = p.As<Product>().DateCome,
                    DateProduction = p.As<Product>().DateProduction
                });

            return query.ResultsAsync.Result;
        }

        public void Save()
        {

        }

        public void Update(WorkerLookCompose item)
        {
            throw new NotImplementedException();
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
