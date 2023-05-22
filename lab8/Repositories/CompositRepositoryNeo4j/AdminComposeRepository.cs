using DB_course.Models.CompositModels;
using DB_course.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Repositories.CompositRepository
{
    public class AdminComposeRepositoryN : INeo4jRepository<AdminCompose>
    {
        private readonly N4jGrafClient _graphClient;

        public IConnection DB { set { } }

        public AdminComposeRepositoryN(IConnection graphClient)
        {
            _graphClient = (N4jGrafClient)graphClient;
        }

        public void Create(AdminCompose item)
        {
            throw new NotImplementedException();
        }

        public void Delete(string key)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<AdminCompose> Get(string value)
        {
            int petId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;

            var query = _graphClient.Cypher
                .Match("(ip:InventoryProduct)-[:HAS_PLACE_OF_OBJECT]->(p:PlaceofObject)")
                .Match("(ip)-[:PRODUCT]->(pr:Product)")
                .Where((InventoryProduct ip) => ip.InventoryNumber == petId)
                .Return((ip, p, pr) => new AdminCompose
                {
                    ProductId = pr.As<Product>().Id,
                    Name = pr.As<Product>().Name,
                    DateCome = pr.As<Product>().DateCome,
                    DateProduction = pr.As<Product>().DateProduction,
                    InventoryNumber = ip.As<InventoryProduct>().InventoryNumber,
                    value = pr.As<Product>().Value,
                    PlaceId = p.As<PlaceofObject>().PlaceId.ToString(),
                    PlaceOfObjectlId = p.As<PlaceofObject>().Id.ToString()
                });

            return query.ResultsAsync.Result;
        }

        public IEnumerable<AdminCompose> GetList()
        {
            var query = _graphClient.Cypher
                .Match("(ip:InventoryProduct)-[:HAS_PLACE_OF_OBJECT]->(p:PlaceofObject)")
                .Match("(ip)-[:PRODUCT]->(pr:Product)")
                .Return((ip, p, pr) => new AdminCompose
                {
                    ProductId = pr.As<Product>().Id,
                    Name = pr.As<Product>().Name,
                    DateCome = pr.As<Product>().DateCome,
                    DateProduction = pr.As<Product>().DateProduction,
                    InventoryNumber = ip.As<InventoryProduct>().InventoryNumber,
                    value = pr.As<Product>().Value,
                    PlaceId = p.As<PlaceofObject>().PlaceId.ToString(),
                    PlaceOfObjectlId = p.As<PlaceofObject>().Id.ToString()
                })
                .OrderBy("InventoryNumber");

            var groupedResult = query.ResultsAsync.Result
                .GroupBy(a => a.InventoryNumber)
                .Select(eg => new AdminCompose
                {
                    ProductId = eg.First().ProductId,
                    Name = eg.First().Name,
                    DateCome = eg.First().DateCome,
                    DateProduction = eg.First().DateProduction,
                    InventoryNumber = eg.Key,
                    value = eg.First().value,
                    PlaceId = string.Join(",", eg.Select(i => i.PlaceId)),
                    PlaceOfObjectlId = string.Join(",", eg.Select(i => i.PlaceOfObjectlId))
                });

            return groupedResult.ToList();
        }

        public void Update(AdminCompose item)
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
