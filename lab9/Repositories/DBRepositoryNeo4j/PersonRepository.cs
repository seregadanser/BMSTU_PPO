using DB_course.Models.DBModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;

namespace DB_course.Repositories.DBRepository
{
    public class PersonRepositoryN : INeo4jRepository<Person>
    {
        private readonly N4jGrafClient _graphClient;

        public IConnection DB { set { } }

        public PersonRepositoryN(IConnection graphClient)
        {
            _graphClient = (N4jGrafClient)graphClient;
        }

        public async void Create(Person item)
        {
            _graphClient.Cypher
               .Create("(n:Person {item})")
               .WithParam("item", item)
               .ExecuteWithoutResultsAsync();
        }

        public void Delete(string key)
        {
            _graphClient.Cypher
                 .Match("(n:Person)")
                 .Where((Person n) => n.Login == key)
                 .Delete("n")
                 .ExecuteWithoutResultsAsync();
        }


        public IEnumerable<Person> Get(string value)
        {
            var query = _graphClient.Cypher
             .Match("(n:Person)")
             .Where((Person n) => n.Name == value || n.Login == value)
             .Return(n => n.As<Person>());

            return  query.ResultsAsync.Result;

        }

        public IEnumerable<Person> GetList()
        {
            return _graphClient.Cypher
            .Match("(n:Person)")
            .Return(n => n.As<Person>()).ResultsAsync.Result;
        }

        public void Save()
        {
        
        }

        public void Update(Person item)
        {
            _graphClient.Cypher
             .Match("(n:Person)")
             .Where((Person n) => n.Login == item.Login)
             .Set("n = {item}")
             .WithParam("item", item)
             .ExecuteWithoutResultsAsync();
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
