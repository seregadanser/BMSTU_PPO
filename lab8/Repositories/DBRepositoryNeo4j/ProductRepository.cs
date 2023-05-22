using DB_course.Models.DBModels;
using DB_course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;

namespace DB_course.Repositories.DBRepository
{
    public class ProductRepositoryN : INeo4jRepository<Product>
    {
        private readonly N4jGrafClient _graphClient;

        public IConnection DB { set { } }

        public ProductRepositoryN(IConnection graphClient)
        {
            _graphClient = (N4jGrafClient)graphClient;
        }


        public void Create(Product item)
        {
            _graphClient.Cypher
             .Create("(n:Product {item})")
             .WithParam("item", item)
             .ExecuteWithoutResultsAsync();
        }

        public void Delete(string key)
        {
            _graphClient.Cypher
              .Match("(n:Product)")
              .Where((Product n) => n.Id == Convert.ToInt32(key))
              .Delete("n")
              .ExecuteWithoutResultsAsync();
        }



        public IEnumerable<Product> Get(string value)
        {
            var query = _graphClient.Cypher
                 .Match("(n:Product)")
                 .Where((Product n) => n.Id == Convert.ToInt32(value))
                 .Return(n => n.As<Product>());

            return query.ResultsAsync.Result;

        }

        public IEnumerable<Product> GetList()
        {
            var query = _graphClient.Cypher
         .Match("(n:Product)")
         .Return(n => n.As<Product>());

            return query.ResultsAsync.Result;
        }

   

        public void Update(Product item)
        {
            _graphClient.Cypher
                  .Match("(n:Product)")
                  .Where((Product n) => n.Id == item.Id)
                  .Set("n = {item}")
                  .WithParam("item", item)
                  .ExecuteWithoutResultsAsync();
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
