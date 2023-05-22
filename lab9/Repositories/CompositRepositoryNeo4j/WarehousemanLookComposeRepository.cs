using DB_course.Models.CompositModels;
using DB_course.Models.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Repositories.CompositRepository
{
    public class WarehousemanLookComposeRepositoryN : INeo4jRepository<WarehousemanLookCompose>
    {
        private readonly N4jGrafClient _graphClient;

        public IConnection DB { set { } }

        public WarehousemanLookComposeRepositoryN(IConnection graphClient)
        {
            _graphClient = (N4jGrafClient)graphClient;
        }

        public void Create(WarehousemanLookCompose item)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<WarehousemanLookCompose> Get(string value)
        {
            int petId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;

            var query = _graphClient.Cypher
                .Match("(po:PlaceofObject)-[:HAS_PLACE]->(p:Place)")
                .Match("(u:Useful)-[:BELONGS_TO]->(pe:Person)")
                .Match("(u)-[:ASSOCIATED_WITH]->(i:InventoryProduct)")
                .Where((InventoryProduct i, Person pe) => i.InventoryNumber == petId ||
                                                         pe.Name == value ||
                                                         pe.SecondName == value)
                .Return((po, p, u, pe, i) => new WarehousemanLookCompose
                {
                    Name = pe.As<Person>().Name,
                    SecondName = pe.As<Person>().SecondName,
                    Login = pe.As<Person>().Login,
                    InventoryNumber = i.As<InventoryProduct>().InventoryNumber,
                    NumberStay = p.As<Place>().NumberStay,
                    NumberLayer = Convert.ToString(p.As<Place>().NumberLayer),
                    DateOfStart = u.As<Useful>().DateOfStart
                });

            return query.ResultsAsync.Result;
        }

        public IEnumerable<WarehousemanLookCompose> GetList()
        {
            var query = _graphClient.Cypher
                .Match("(po:PlaceofObject)-[:HAS_PLACE]->(p:Place)")
                .Match("(u:Useful)-[:BELONGS_TO]->(pe:Person)")
                .Match("(u)-[:ASSOCIATED_WITH]->(i:InventoryProduct)")
                .Return((po, p, u, pe, i) => new WarehousemanLookCompose
                {
                    InventoryNumber = u.As<Useful>().InventoryId,
                    Name = pe.As<Person>().Name,
                    SecondName = pe.As<Person>().SecondName,
                    Login = pe.As<Person>().Login,
                    NumberStay = p.As<Place>().NumberStay,
                    NumberLayer = Convert.ToString(p.As<Place>().NumberLayer),
                    DateOfStart = u.As<Useful>().DateOfStart
                })
                .OrderByDescending("Login");

            var groupedResult = query.ResultsAsync.Result
                .GroupBy(a => a.Login)
                .Select(eg => new WarehousemanLookCompose
                {
                    Login = eg.Key,
                    Name = eg.First().Name,
                    SecondName = eg.First().SecondName,
                    InventoryNumber = eg.First().InventoryNumber,
                    DateOfStart = eg.First().DateOfStart,
                    NumberStay = eg.First().NumberStay,
                    NumberLayer = string.Join(",", eg.Select(i => i.NumberLayer))
                }); 
            return groupedResult.ToList();
        }


        public void Save()
        {
           
        }

        public void Update(WarehousemanLookCompose item)
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
