using DB_course.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_course.Models;
using DB_course.Models.DBModels;
using DB_course.Models.CompositModels;

namespace DB_course.Presenter
{
    public class WorkerPresenter
    {
        private IWorkerView view;
        private AWorkerModel model;
        private BindingSource productsBindingSource;
        private IEnumerable<WorkerLookCompose> productList;
        private BindingSource usingBindingSource;
        private IEnumerable<WorkerLookUsefulCompose> usingList;

        //Constructor
        public WorkerPresenter(IWorkerView view, IModel model)
        {
            this.productsBindingSource = new BindingSource();
            this.usingBindingSource = new BindingSource();
            this.view = view;
            this.model = (AWorkerModel)model;

            
            //Set pets bindind source
            this.view.SetProductsListBindingSource(productsBindingSource);
            this.view.SetUsingListBindingSource(usingBindingSource);
            LoadAllLists();

            this.view.SearchEvent += SearchProduct;
            this.view.DeleteEvent += DeleteSelectedUseful;
            this.view.AddNewEvent += AddNewUsing;

            this.view.Show();
        }
        //Methods
        private void LoadAllLists()
        {
            productList = model.LookProducts();
            usingList = model.LookUsing();
            productsBindingSource.DataSource = productList;
            usingBindingSource.DataSource = usingList;  
        }
        private void SearchProduct(object sender, EventArgs e)
        {
            productList = model.LookProducts(view.SearchValue);
            productsBindingSource.DataSource = productList;
        }
       
        private void DeleteSelectedUseful(object sender, EventArgs e)
        {
            try
            {
                var worker = (WorkerLookUsefulCompose)usingBindingSource.Current;
                if (worker == null) throw new Exception("Cant delit empty useful product");
                model.DelitUseful(worker.Inventory_number);
                view.IsSuccessful = true;
                view.Message = "useful deleted successfully";
                productList = model.LookProducts();
                usingList = model.LookUsing();
                productsBindingSource.DataSource = productList;
                usingBindingSource.DataSource = usingList;

            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }
        private void AddNewUsing(object sender, EventArgs e)
        {
            try
            {
                var product = (WorkerLookCompose)productsBindingSource.Current;
                if (product == null) throw new Exception("An error ocurred, could not ass worker");
                model.AddUseful(product);
                view.Message = "product added sucessfully";
                productList = model.LookProducts();
                usingList = model.LookUsing();
                productsBindingSource.DataSource = productList;
                usingBindingSource.DataSource = usingList;
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message =ex.Message;
            }
        }
    }
}
