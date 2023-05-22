using DB_course.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;

namespace DB_course.Repositories.DBRepository
{
    public class InventoryProductRepositoryN : INeo4jRepository<InventoryProduct>
    {
        private readonly N4jGrafClient _graphClient;
    public IConnection DB { set { } }

        public InventoryProductRepositoryN(IConnection graphClient)
        {
            _graphClient = (N4jGrafClient)graphClient;
        }

        public void Create(InventoryProduct item)
        {
            _graphClient.Cypher
            .Create("(n:InventoryProduct {item})")
            .WithParam("item", item).ExecuteWithoutResultsAsync();
        }

        public void Delete(string key)
        {
            _graphClient.Cypher
                       .Match("(n:InventoryProduct)")
                       .Where((InventoryProduct n) => n.InventoryNumber == Convert.ToInt32(key))
                       .Delete("n").ExecuteWithoutResultsAsync();
        }

   

        public IEnumerable<InventoryProduct> Get(string value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InventoryProduct> GetList()
        {
            return _graphClient.Cypher
         .Match("(n:InventoryProduct)")
         .Return(n => n.As<InventoryProduct>()).ResultsAsync.Result;
        }



        public void Update(InventoryProduct item)
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
