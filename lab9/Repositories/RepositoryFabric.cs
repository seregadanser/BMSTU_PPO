using DB_course.Models.DBModels;
using DB_course.Models;
using DB_course.Repositories.DBRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_course.Repositories.CompositRepository;
using DB_course.Models.CompositModels;

namespace DB_course.Repositories
{

    public interface IRepositoryAbstractFabric
    {
        public IRepository<Person> CreatePersonR();
        public IRepository<Place> CreatePlaceR();
        public IRepository<Useful> CreateUsefulR();
        public IRepository<WarehousemanLookCompose> CreateWarehousemanLookComposeRepositoryR();
        public IRepository<WorkerLookUsefulCompose> CreateWorkerLookUsefulComposeR();
        public IRepository<WorkerLookCompose> CreateWorkerLookComposeR();
        public IRepository<Product> CreateProductR();
        public IRepository<InventoryProduct> CreateInventoryProductR();
        public IRepository<PlaceofObject> CreatePlaceofObjectR();
        public IRepository<AdminCompose> CreateAdminComposeR();

    }
    public class SQLRepositoryAbstractFabric : IRepositoryAbstractFabric
    {
        IConnection connection;

        public SQLRepositoryAbstractFabric(IConnection connection)
        {
            this.connection = connection;
        }

        public IRepository<AdminCompose> CreateAdminComposeR()
        {
           return new AdminComposeRepository(connection);
        }

        public IRepository<InventoryProduct> CreateInventoryProductR()
        {
            return new InventoryProductRepository(connection);
        }

        public IRepository<Person> CreatePersonR()
        {
            return new PersonRepository(connection);
        }

        public IRepository<PlaceofObject> CreatePlaceofObjectR()
        {
            return new PlaceofObjectRepository(connection);
        }

        public IRepository<Place> CreatePlaceR()
        {
            return new PlaceRepository(connection);
        }

        public IRepository<Product> CreateProductR()
        {
            return new ProductRepository(connection);
        }

        public IRepository<Useful> CreateUsefulR()
        {
            return new UsefulRepository(connection);
        }
        public IRepository<WarehousemanLookCompose> CreateWarehousemanLookComposeRepositoryR()
        {
            return new WarehousemanLookComposeRepository(connection);
        }

        public IRepository<WorkerLookCompose> CreateWorkerLookComposeR()
        {
            return new WorkerLookComposeRepository(connection);
        }

        public IRepository<WorkerLookUsefulCompose> CreateWorkerLookUsefulComposeR()
        {
            return new WorkerLookUsefulComposeRepository(connection);
        }
    }

    public class Neo4jRepositoryAbstractFabric : IRepositoryAbstractFabric
    {
        IConnection connection;

        public Neo4jRepositoryAbstractFabric(IConnection connection)
        {
            this.connection = connection;
            ((N4jGrafClient)connection).ConnectAsync();
        }

        public IRepository<AdminCompose> CreateAdminComposeR()
        {
            return new AdminComposeRepositoryN(connection);
        }

        public IRepository<InventoryProduct> CreateInventoryProductR()
        {
            return new InventoryProductRepositoryN(connection);
        }

        public IRepository<Person> CreatePersonR()
        {
            return new PersonRepositoryN(connection);
        }

        public IRepository<PlaceofObject> CreatePlaceofObjectR()
        {
            return new PlaceofObjectRepositoryN(connection);
        }

        public IRepository<Place> CreatePlaceR()
        {
            return new PlaceRepositoryN(connection);
        }

        public IRepository<Product> CreateProductR()
        {
            return new ProductRepositoryN(connection);
        }

        public IRepository<Useful> CreateUsefulR()
        {
            return new UsefulRepositoryN(connection);
        }
        public IRepository<WarehousemanLookCompose> CreateWarehousemanLookComposeRepositoryR()
        {
            return new WarehousemanLookComposeRepositoryN(connection);
        }

        public IRepository<WorkerLookCompose> CreateWorkerLookComposeR()
        {
            return new WorkerLookComposeRepositoryN(connection);
        }

        public IRepository<WorkerLookUsefulCompose> CreateWorkerLookUsefulComposeR()
        {
            return new WorkerLookUsefulComposeRepositoryN(connection);
        }
    }
}
