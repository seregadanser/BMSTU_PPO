using DB_course.Models.DBModels;
using DB_course.Models.CompositModels;
using DB_course.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DB_course.Models
{
    public class WarehouseAdminModel : IModel
    {
        private IUnitOfWork unitOfWork;
        public IUnitOfWork UnitOfWork { get { return unitOfWork; } }
 
        public WarehouseAdminModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        
        public void AddPlace(Place place)
        {
            new DataValidateModel().Validate(place);
            unitOfWork.PlaceRepository.Create(place);
            unitOfWork.PlaceRepository.Save();
        }
        public void RemovePlace(int key)
        {
            if(key <= 0)
                throw new Exception("Invalid Id");
            unitOfWork.PlaceRepository.Delete(Convert.ToString(key));
            unitOfWork.PlaceRepository.Save();
        }
        public void UpdatePlace(int key, Place newPlace)
        {
            if(key <= 0)
                throw new Exception("Invalid Id");
            new DataValidateModel().Validate(newPlace);
            Place curperson = null;
            try
            {
                curperson = unitOfWork.PlaceRepository.Get(Convert.ToString(key)).First();}
            catch { throw new Exception("No such place for update"); }
                if(curperson == null)
                    throw new Exception("No such place for update");
           
           
            curperson.NumberLayer = newPlace.NumberLayer;
            curperson.NumberStay = newPlace.NumberStay;
            curperson.Size = newPlace.Size;
            curperson.Id = newPlace.Id;

            unitOfWork.PlaceRepository.Update(curperson);
            unitOfWork.PlaceRepository.Save();

        }
        public IEnumerable<Place> GetPlace()
        {
            return unitOfWork.PlaceRepository.GetList();
        }
        public IEnumerable<Place> GetPlace(string value)
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

        public void AddProduct(AdminCompose value)
        {
            InventoryProduct newInventory = new InventoryProduct();
            PlaceofObject newPlaceofObject = new PlaceofObject();
            Product newProduct = new Product();

            newProduct.DateProduction = value.DateProduction;
            newProduct.DateCome = value.DateCome;
            newProduct.Name = value.Name;
            newProduct.Id = (int)value.ProductId;
            Product p = null;
            try
            { p = unitOfWork.ProductRepository.Get(Convert.ToString(newProduct.Id)).First(); }
            catch { }
            if(p == null)
            {
                newProduct.Value = 1;
                new DataValidateModel().Validate(newProduct);
                unitOfWork.ProductRepository.Create(newProduct);
            }
            else
            {
                p.Value++;
                unitOfWork.ProductRepository.Update(p);
            }
            unitOfWork.ProductRepository.Save();

            newInventory.InventoryNumber = value.InventoryNumber;
            newInventory.ProductId = value.ProductId;
            new DataValidateModel().Validate(newInventory);
            unitOfWork.InventoryProductRepository.Create(newInventory);
            unitOfWork.InventoryProductRepository.Save();

            IEnumerable<PlaceofObject> l = unitOfWork.PlaceofObjectRepository.GetList();
            int maxId = l.Last().Id + 1;
            string[] places = value.PlaceId.Split(',');
            for(int i = 0; i < places.Length; i++)
            {
                newPlaceofObject.Id = maxId;
                newPlaceofObject.PlaceId = Convert.ToInt32(places[i]);
                newPlaceofObject.InventoryId = value.InventoryNumber;
                unitOfWork.PlaceofObjectRepository.Create(newPlaceofObject);
                unitOfWork.PlaceofObjectRepository.Save();
                maxId++;
            }                    
        }
        public void RemoveProduct(AdminCompose value)
        {
            //добавить проверку на присутствие инвентарного предмета в useful
            
            string[] places = value.PlaceId.Split(',');
            for(int i = 0; i < places.Length; i++)
            {
                unitOfWork.PlaceofObjectRepository.Delete(places[i]);
                unitOfWork.PlaceofObjectRepository.Save();
            }

            unitOfWork.InventoryProductRepository.Delete(Convert.ToString(value.InventoryNumber));
            unitOfWork.InventoryProductRepository.Save();

            Product p = unitOfWork.ProductRepository.Get(Convert.ToString(value.ProductId)).First();
            if(p == null)
                throw new Exception("Product not found");

            if(p.Value > 1)
            {
                p.Value--;
                unitOfWork.ProductRepository.Update(p);
            }
            else
                unitOfWork.ProductRepository.Delete(Convert.ToString(p.Id));
            unitOfWork.ProductRepository.Save();

        }
        public IEnumerable<AdminCompose> GetProducts()
        {
            return unitOfWork.AdminComposeRepository.GetList();
        }
        public IEnumerable<AdminCompose> GetProducts(string value)
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
}
