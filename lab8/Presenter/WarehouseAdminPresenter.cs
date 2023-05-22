using DB_course.Models.CompositModels;
using DB_course.Models;
using DB_course.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_course.Models.DBModels;
using System.Globalization;

namespace DB_course.Presenter
{
    public class WarehouseAdminPresenter
    {
        private IWarehouseAdminView view;
        private AWarehouseAdminModel model;
        private BindingSource productsBindingSource;
        private IEnumerable<AdminCompose> productList;
        private BindingSource placesBindingSource;
        private IEnumerable<Place> placesList;

        //Constructor
        public WarehouseAdminPresenter(IWarehouseAdminView view, IModel model)
        {
            this.productsBindingSource = new BindingSource();
            placesBindingSource = new BindingSource();

            this.view = view;
            this.model = (AWarehouseAdminModel)model;


            //Set pets bindind source
            this.view.SetProductListBindingSource(productsBindingSource);
            this.view.SetPlaceListBindingSource(placesBindingSource);
            LoadAllLists();

            this.view.DeleteEvent += DeleteSelectedProduct;
            this.view.SaveEvent += AddNewProduct;
            this.view.CancelEvent += CancelAction;
            this.view.SearchEvent += SearchProduct;
            this.view.AddNewPlaceEvent += AddNewPlace;
            this.view.CancelPlaceEvent += PlaceCancelAction;
            this.view.EditPlaceEvent += LoadSelectedPlaceToEdit;
            this.view.SavePlaceEvent += SavePlace;
            this.view.DeletePlaceEvent += DeleteSelectedPlace;
            this.view.SearchPlaceEvent += SearchPlace;
            this.view.Show();
        }
        //Methods

        private void SearchPlace(object sender, EventArgs e)
        {
            placesList = model.GetPlace(view.SearchPlaceValue);
            placesBindingSource.DataSource = placesList;

        }
        private void PlaceCancelAction(object sender, EventArgs e)
        {
            view.PlaceId1 = "";
            view.PlaceLayer = "";
            view.PlaceSize = "";
            view.PlaceStay = "";
        }
        private void SavePlace(object sender, EventArgs e)
        {
            try
            {
                var place = new Place();
                place.NumberLayer = int.TryParse(view.PlaceLayer, out _) ? Convert.ToInt32(view.PlaceLayer) : throw new Exception("invalid layer");
                place.NumberStay = int.TryParse(view.PlaceStay, out _) ? Convert.ToInt32(view.PlaceStay) : throw new Exception("invalid stay");
                place.Id = int.TryParse(view.PlaceId1, out _) ? Convert.ToInt32(view.PlaceId1) : throw new Exception("invalid id");
                place.Size = int.TryParse(view.PlaceSize, out _) ? Convert.ToInt32(view.PlaceSize) : throw new Exception("invalid size");


                if (view.IsEdit)
                {
                    model.UpdatePlace(place.Id,place);
                    view.Message = "place edited successfuly";
                }
                else
                {

                    model.AddPlace(place);
                    view.Message = "worker added sucessfully";
                }

                view.IsSuccessful = true;
                placesList = model.GetPlace();
                placesBindingSource.DataSource = placesList;

                view.PlaceId1 = "";
                view.PlaceLayer = "";
                view.PlaceStay = "";
                view.PlaceSize = "";
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }
        private void DeleteSelectedPlace(object sender, EventArgs e)
        {
            try
            {
                var place = (Place)placesBindingSource.Current ?? throw new Exception("Empty product");
                model.RemovePlace(place.Id);
                view.IsSuccessful = true;
                view.Message = "worker deleted successfully";
                placesList = model.GetPlace();
                placesBindingSource.DataSource = placesList;

            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }
        
        private void LoadSelectedPlaceToEdit(object sender, EventArgs e)
        {
            try
            {
                Place worker = (Place)placesBindingSource.Current ?? throw new Exception("Empty product");

                view.PlaceId1 = Convert.ToString( worker.Id);
                view.PlaceLayer = Convert.ToString(worker.NumberLayer);
                view.PlaceStay = Convert.ToString(worker.NumberStay);
                view.PlaceSize = Convert.ToString(worker.Size);

                view.IsEdit = true;
                view.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }

        private void AddNewPlace(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void LoadAllLists()
        {
            productList = model.GetProducts();
            productsBindingSource.DataSource = productList;
            placesList = model.GetPlace();
            placesBindingSource.DataSource = placesList;
        }
        private void SearchProduct(object sender, EventArgs e)
        {
            productList = model.GetProducts(view.SearchValue);
            productsBindingSource.DataSource = productList;
        }
        private void CancelAction(object sender, EventArgs e)
        {
            view.ProductId = 0;
            view.DateCome = "";
            view.PlaceId = "";
            view.InventoryNumber = 0;
            view.DateProduction = "";
            view.ProductName = "";
        }

        private void DeleteSelectedProduct(object sender, EventArgs e)
        {
            try
            {
                var worker = (AdminCompose)productsBindingSource.Current;
                if(worker == null)
                    throw new Exception("Cant delit empty person");
                model.RemoveProduct(worker);
                view.IsSuccessful = true;
                view.Message = "worker deleted successfully";
                productList = model.GetProducts();
                productsBindingSource.DataSource = productList;

            }
            catch(Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }

        private void AddNewProduct(object sender, EventArgs e)
        {
            try
            {
                var product = new AdminCompose();
                product.DateCome = DateTime.ParseExact(view.DateCome, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                product.ProductId = view.ProductId;
                product.PlaceId = view.PlaceId;
                product.InventoryNumber = view.InventoryNumber;
                product.DateProduction = DateTime.ParseExact(view.DateProduction, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                product.Name = view.ProductName;

                model.AddProduct(product);
                view.Message = "product added sucessfully";

                view.IsSuccessful = true;
                productList = model.GetProducts();
                productsBindingSource.DataSource = productList;

                CancelAction(sender, e);

            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }
    }
}
