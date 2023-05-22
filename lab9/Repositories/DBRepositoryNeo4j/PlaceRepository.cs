using DB_course.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;

namespace DB_course.Repositories.DBRepository
{
    public class PlaceRepositoryN : INeo4jRepository<Place>
    {

        private readonly N4jGrafClient _graphClient;

        public IConnection DB { set { } }

        public PlaceRepositoryN(IConnection graphClient)
        {
            _graphClient = (N4jGrafClient)graphClient;
        }
        public void Create(Place item)
        {
            _graphClient.Cypher
            .Create("(n:Place {item})")
            .WithParam("item", item)
            .ExecuteWithoutResultsAsync();
        }

        public void Delete(string id)
        {
            _graphClient.Cypher
             .Match("(n:Place)")
             .Where((Place n) => n.Id == Convert.ToInt32(id))
             .Delete("n")
             .ExecuteWithoutResultsAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Place> Get(string value)
        {
            var query = _graphClient.Cypher
            .Match("(n:Place)")
            .Where((Place n) => n.Id == Convert.ToInt32(value))
            .Return(n => n.As<Place>());

            return query.ResultsAsync.Result;
        }

        public IEnumerable<Place> GetList()
        {
            return _graphClient.Cypher
            .Match("(n:Place)")
            .Return(n => n.As<Place>()).ResultsAsync.Result;
        }

        public void Save()
        {
           
        }

        public void Update(Place item)
        {
            throw new NotImplementedException();
        }
    }
}
