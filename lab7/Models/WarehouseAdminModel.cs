using DB_course.Models.DBModels;
using DB_course.Models.CompositModels;
using DB_course.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;

namespace DB_course.Models
{
    public abstract class AWarehouseAdminModel : IModel
    {
        private IUnitOfWork unitOfWork;
        public IUnitOfWork UnitOfWork { get { return unitOfWork; } }
 
        public AWarehouseAdminModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        
        public virtual void AddPlace(Place place)
        {
            new DataValidateModel().Validate(place);
            unitOfWork.PlaceRepository.Create(place);
            unitOfWork.PlaceRepository.Save();
        }
        public virtual void RemovePlace(int key)
        {
            IEnumerable<PlaceofObject> u = unitOfWork.PlaceofObjectRepository.GetList();
            foreach (PlaceofObject useful in u)
                if (useful.PlaceId == key)
                    throw new Exception("Place in useful");
            if (key <= 0)
                throw new IdException("Invalid Id");
            unitOfWork.PlaceRepository.Delete(Convert.ToString(key));
            unitOfWork.PlaceRepository.Save();
        }
        public virtual void UpdatePlace(int key, Place newPlace)
        {
            if(key <= 0)
                throw new IdException("Invalid Id");
            new DataValidateModel().Validate(newPlace);
            Place curperson = null;
            try
            {
                curperson = unitOfWork.PlaceRepository.Get(Convert.ToString(key)).First();}
            catch { throw new NoSuchObjectException("No such place for update"); }
                if(curperson == null)
                    throw new NoSuchObjectException("No such place for update");
           
           
            curperson.NumberLayer = newPlace.NumberLayer;
            curperson.NumberStay = newPlace.NumberStay;
            curperson.Size = newPlace.Size;
            curperson.Id = newPlace.Id;

            unitOfWork.PlaceRepository.Update(curperson);
            unitOfWork.PlaceRepository.Save();

        }
        public virtual IEnumerable<Place> GetPlace()
        {
            return unitOfWork.PlaceRepository.GetList();
        }
        public virtual IEnumerable<Place> GetPlace(string value)
        {
            IEnumerable<Place> personList;
            bool emptyValue = string.IsNullOrWhiteSpace(value);
            if(emptyValue == false)
                personList = unitOfWork.PlaceRepository.Get(value);
            else
            {
                personList = unitOfWork.PlaceRepository.GetList();
            }
            return personList;
        }

        public virtual void AddProduct(AdminCompose value)
        {
            InventoryProduct newInventory = new InventoryProduct();
            PlaceofObject newPlaceofObject = new PlaceofObject();
            Product newProduct = new Product();

            newProduct.DateProduction = value.DateProduction;
            newProduct.DateCome = value.DateCome;
            newProduct.Name = value.Name;
            newProduct.Id = (int)value.ProductId;

            newInventory.InventoryNumber = (int)value.InventoryNumber;
            newInventory.ProductId = value.ProductId;
            new DataValidateModel().Validate(newInventory);

            IEnumerable<PlaceofObject> l = null;
       

            int maxId = -1;
            l = unitOfWork.PlaceofObjectRepository.GetList();
            try
            {
                 maxId = l.Last().Id + 1;
            }
            catch{ maxId = 0;  }

            string[] places = value.PlaceId.Split(',');
            List<PlaceofObject> ll = new List<PlaceofObject>();

            for(int i = 0; i < places.Length; i++)
            {
                try{ unitOfWork.PlaceRepository.Get(places[i]).First(); } catch { throw new Exception("Place" + places[i] + "not exists"); }
                ll.Add(new PlaceofObject { PlaceId = Convert.ToInt32(places[i]), Id = maxId, InventoryId = value.InventoryNumber });
                new DataValidateModel().Validate(ll[i]);
                maxId++;
            }

            Product? p = null;
            try
            {
                p = unitOfWork.ProductRepository.Get(Convert.ToString(newProduct.Id))?.First();
            }
            catch { p = null; }

            if(p == null)
            {
                newProduct.Value = 1;
                new DataValidateModel().Validate(newProduct);
                unitOfWork.ProductRepository.Create(newProduct);
            }
            else
            {
                if(p.Name == value.Name && p.DateProduction == value.DateProduction && p.DateCome == value.DateCome)
                {
                    p.Value++;
                    unitOfWork.ProductRepository.Update(p);
                }
                else
                {
                    newProduct.Value = 1;
                    new DataValidateModel().Validate(newProduct);
                    unitOfWork.ProductRepository.Create(newProduct);
                }
            }
            unitOfWork.ProductRepository.Save();

            unitOfWork.InventoryProductRepository.Create(newInventory);
            try
            {
                unitOfWork.InventoryProductRepository.Save();
            }
            catch
            {
                p = unitOfWork.ProductRepository.Get(Convert.ToString(newProduct.Id))?.First();
                if(p.Value > 1)
                {
                    p.Value--;
                    unitOfWork.ProductRepository.Update(p);
                }
                else
                    unitOfWork.ProductRepository.Delete(Convert.ToString(p.Id));
                unitOfWork.ProductRepository.Save();
                throw new Exception("inventory number already in use");
            }
            string placesi = "";
            foreach(PlaceofObject pp in ll)
            {
                unitOfWork.PlaceofObjectRepository.Create(pp);
                placesi += pp.PlaceId + ",";
                try
                {
                    unitOfWork.PlaceofObjectRepository.Save();
                }
                catch{
                    RemoveProduct(new AdminCompose(){ PlaceId = placesi, InventoryNumber = value.InventoryNumber, ProductId = value.ProductId });
                    throw new Exception("Places exeption");
                }
            }

        }
        public virtual void RemoveProduct(AdminCompose value)
        {
            IEnumerable<Useful> u = unitOfWork.UsefulRepository.GetList();
            foreach (Useful useful in u)
                if (useful.InventoryId == value.InventoryNumber)
                    throw new Exception("Object in useful");

            string[] places = value.PlaceOfObjectlId.Split(',');
            for(int i = 0; i < places.Length; i++)
            {
                unitOfWork.PlaceofObjectRepository.Delete(places[i]);
                unitOfWork.PlaceofObjectRepository.Save();
            }

            unitOfWork.InventoryProductRepository.Delete(Convert.ToString(value.InventoryNumber));
            unitOfWork.InventoryProductRepository.Save();

            Product p = unitOfWork.ProductRepository.Get(Convert.ToString(value.ProductId))?.First() 
                    ?? throw new NoSuchObjectException("Product not found");


            if(p.Value > 1)
            {
                p.Value--;
                unitOfWork.ProductRepository.Update(p);
            }
            else
                unitOfWork.ProductRepository.Delete(Convert.ToString(p.Id));
            unitOfWork.ProductRepository.Save();

        }
        public virtual IEnumerable<AdminCompose> GetProducts()
        {
            return unitOfWork.AdminComposeRepository.GetList();
        }
        public virtual IEnumerable<AdminCompose> GetProducts(string value)
        {
            IEnumerable<AdminCompose> personList;
            bool emptyValue = string.IsNullOrWhiteSpace(value);
            if(emptyValue == false)
                personList = unitOfWork.AdminComposeRepository.Get(value);
            else
            {
                personList = unitOfWork.AdminComposeRepository.GetList();
            }
            return personList;
        }
    }
    public class WarehouseAdminModel : AWarehouseAdminModel
    {
        public WarehouseAdminModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }

    public abstract class AWarehouseAdminModelDecorator : AWarehouseAdminModel
    {
        protected AWarehouseAdminModel model;
        protected readonly ILogger<AWarehouseAdminModel> logger;
        public AWarehouseAdminModelDecorator(AWarehouseAdminModel model, ILoggerFactory loggerFactory) : base(model.UnitOfWork)
        {
            this.model = model;
            logger = loggerFactory.CreateLogger<AWarehouseAdminModel>();
        }
    }

    public class WarehouseAdminModelDecorator : AWarehouseAdminModelDecorator
    { 
        public WarehouseAdminModelDecorator(AWarehouseAdminModel model,  ILoggerFactory loggerFactory) : base(model, loggerFactory)
        {

        }
        public override void AddPlace(Place place)
        {
            try
            {
                model.AddPlace(place);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw ex;
            }
            logger.LogInformation($"Place {place.Id} added succed");
        }
        public override void RemovePlace(int key)
        {
            try
            {
                model.RemovePlace(key);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw ex;
            }
            logger.LogInformation($"Place {key} removed succed");
        }
        public override void UpdatePlace(int key, Place newPlace)
        {
            try
            {
                model.UpdatePlace(key, newPlace);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw ex;
            }
            logger.LogInformation($"Place {key} updated succed");
        }

        public override void AddProduct(AdminCompose value)
        {
            try
            {
                model.AddProduct(value);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw ex;
            }
            logger.LogInformation($"Product {value.InventoryNumber} added succed");
        }
        public override void RemoveProduct(AdminCompose value)
        {
            try
            {
                model.RemoveProduct(value); 
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw ex;
            }
            logger.LogInformation($"Product {value.InventoryNumber} removed succed");
        }

    }
}
