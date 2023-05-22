using DB_course.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;

namespace DB_course.Repositories.DBRepository
{
    public class PlaceofObjectRepositoryN : INeo4jRepository<PlaceofObject>
    {
        private readonly N4jGrafClient _graphClient;

        public IConnection DB { set {  } }

        public PlaceofObjectRepositoryN(IConnection graphClient)
        {
            _graphClient = (N4jGrafClient)graphClient;
        }

        public void Create(PlaceofObject item)
        {
            _graphClient.Cypher
      .Create("(n:PlaceofObject {item})")
      .WithParam("item", item)
      .ExecuteWithoutResultsAsync();
        }

        public void Delete(string key)
        {
            _graphClient.Cypher
              .Match("(n:PlaceofObject)")
              .Where((PlaceofObject n) => n.Id == Convert.ToInt32(key))
              .Delete("n")
              .ExecuteWithoutResultsAsync();
        }

 

        public IEnumerable<PlaceofObject> Get(string value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlaceofObject> GetList()
        {
            return _graphClient.Cypher
            .Match("(n:PlaceofObject)")
            .Return(n => n.As<PlaceofObject>()).ResultsAsync.Result;
        }

        public void Update(PlaceofObject item)
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
