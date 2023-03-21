using DB_course.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_course.Repositories.DBRepository;
using DB_course.Repositories.CompositRepository;
using DB_course.Models.CompositModels;

namespace DB_course.Repositories
{

    public interface IUnitOfWork
    {
        IRepository<Person> personRepository { get; }
        IRepository<Place> PlaceRepository { get; }
        IRepository<Useful> UsefulRepository { get; }
        IRepository<WarehousemanLookCompose> WarehousemanLookComposeRepository { get; }
        IRepository<WorkerLookUsefulCompose> WorkerLookUsefulComposeRepository { get; }
        IRepository<WorkerLookCompose> WorkerLookComposeRepository { get; }
        IRepository<Product> ProductRepository { get; }
        IRepository<PlaceofObject> PlaceofObjectRepository { get; }
        IRepository<InventoryProduct> InventoryProductRepository { get; }
        IRepository<AdminCompose> AdminComposeRepository { get; }
        public void UpdateRepository(IRepositoryAbstractFabric fabric);

    }

    public class UnitOfWork : IUnitOfWork
    {
        private IRepositoryAbstractFabric fabric;

        private IRepository<Person> personRep;
        private IRepository<Place> placeRep;
        private IRepository<Useful> usefulRep;
        private IRepository<WarehousemanLookCompose> warehousemanLookComposeRep;
        private IRepository<WorkerLookUsefulCompose> workerLookUsefulComposeRep;
        private IRepository<WorkerLookCompose> workerLookComposeRep;
        private IRepository<PlaceofObject> placeofObjectRep;
        private IRepository<Product> productRep;
        private IRepository<InventoryProduct> inventoryProductRep;
        private IRepository<AdminCompose> adminComposeRep;

        public IRepository<Person> personRepository
        {
            get  
            {
                if(personRep == null)
                    personRep = fabric.CreatePersonR();
                return personRep;
            }
        }

        public IRepository<Place> PlaceRepository
        {
            get
            {
                if(placeRep == null)
                    placeRep = fabric.CreatePlaceR();
                return placeRep;
            }
        }

        public IRepository<Useful> UsefulRepository
        {
            get
            {
                if(usefulRep == null)
                    usefulRep = fabric.CreateUsefulR();
                return usefulRep;
            }
        }
        public IRepository<WarehousemanLookCompose> WarehousemanLookComposeRepository {
            get
            {

                if(warehousemanLookComposeRep == null)
                    warehousemanLookComposeRep = fabric.CreateWarehousemanLookComposeRepositoryR();
                return warehousemanLookComposeRep;

            }
        }

        public IRepository<WorkerLookUsefulCompose> WorkerLookUsefulComposeRepository
        {
            get
            {

                if(workerLookUsefulComposeRep == null)
                    workerLookUsefulComposeRep = fabric.CreateWorkerLookUsefulComposeR();
                return workerLookUsefulComposeRep;

            }
        }
        public IRepository<WorkerLookCompose> WorkerLookComposeRepository
        {
            get
            {

                if(workerLookComposeRep == null)
                    workerLookComposeRep = fabric.CreateWorkerLookComposeR();
                return workerLookComposeRep;

            }
        }

        public IRepository<Product> ProductRepository
        {
            get
            {

                if(productRep == null)
                    productRep = fabric.CreateProductR();
                return productRep;

            }
        }


        public IRepository<PlaceofObject> PlaceofObjectRepository
        {
            get
            {

                if(placeofObjectRep == null)
                    placeofObjectRep = fabric.CreatePlaceofObjectR();
                return placeofObjectRep;

            }
        }

        public IRepository<InventoryProduct> InventoryProductRepository
        {
            get
            {
                if(inventoryProductRep == null)
                    inventoryProductRep = fabric.CreateInventoryProductR();
                return inventoryProductRep;
            }
        }

        public IRepository<AdminCompose> AdminComposeRepository
        {
            get
            {
                if(adminComposeRep == null)
                    adminComposeRep = fabric.CreateAdminComposeR();
                return adminComposeRep;
            }
        }

        public UnitOfWork(IRepositoryAbstractFabric fabric)
        {
            this.fabric = fabric;
        }

        public void UpdateRepository(IRepositoryAbstractFabric fabric)
        {
            this.fabric = fabric;
            personRep = null;
            placeRep = null;
            usefulRep = null;
            warehousemanLookComposeRep = null;
            placeofObjectRep = null;
            productRep = null;
            inventoryProductRep = null;
            adminComposeRep = null;
            workerLookUsefulComposeRep = null;
            workerLookComposeRep = null;

        }
    }
}
