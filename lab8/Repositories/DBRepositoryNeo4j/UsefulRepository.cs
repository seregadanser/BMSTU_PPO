using DB_course.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;

namespace DB_course.Repositories.DBRepository
{
    public class UsefulRepositoryN : INeo4jRepository<Useful>
    {

        private readonly N4jGrafClient _graphClient;

        public IConnection DB { set {  } }

        public UsefulRepositoryN(IConnection graphClient)
        {
            _graphClient = (N4jGrafClient)graphClient;
        }

        public void Create(Useful item)
        {
            _graphClient.Cypher
             .Create("(n:Useful {item})")
             .WithParam("item", item)
             .ExecuteWithoutResultsAsync();
        }

        public void Delete(string key)
        {
            int id;
            if (!int.TryParse(key, out id))
                throw new Exception("Invalid key");

            _graphClient.Cypher
                .Match("(n:Useful)")
                .Where((Useful n) => n.InventoryId == id)
                .Delete("n")
                .ExecuteWithoutResultsAsync();
        }


        public IEnumerable<Useful> Get(string value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Useful> GetList()
        {
            var query = _graphClient.Cypher
               .Match("(n:Useful)")
               .Return(n => n.As<Useful>());

            return query.ResultsAsync.Result;
        }

        public void Save()
        {
    
        }

        public void Update(Useful item)
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
