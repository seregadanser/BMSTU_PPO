using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.View
{
    public interface IMainView : IView
    {
        event EventHandler ShowWorker;
        event EventHandler ShowAdmin;
        event EventHandler ShowHrAdmin;
        event EventHandler ShowWarer;
    }

    public interface IView
     { 
        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        void Show();
        void Close();
    }

    public interface IUnLoginView : IView
    {
        public string WorkerLogin { get; set; }
        public string WorkerPassword { get; set; }

        event EventHandler SaveEvent;
    }

    public interface IWorkerView  : IView
    {
        void SetProductsListBindingSource(BindingSource petList);
        void SetUsingListBindingSource(BindingSource petList);
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler DeleteEvent;
    }

    public interface IHRAdminView   : IView
    {

        public string WorkerPassword { get; set; }
        string WorkerName { get; set; }
        string WorkerSecondName { get; set; }
        string WorkerPosition { get; set; }
        string WorkerBirthday { get; set; }
        public string WorkerLogin { get; set; }

        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        void SetWorkerListBindingSource(BindingSource WorkerList);
    }
    public interface IWarehouseAdminView : IView
    {

        public string PlaceId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string DateCome { get; set; }
        public string DateProduction { get; set; }
        public int InventoryNumber { get; set; }

        public string PlaceId1 { get; set; }
        public string PlaceSize { get; set; }
        public string PlaceLayer { get; set; }
        public string PlaceStay { get; set; }
        public string SearchPlaceValue { get; set; }


        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        event EventHandler SearchPlaceEvent;
        event EventHandler AddNewPlaceEvent;
        event EventHandler EditPlaceEvent;
        event EventHandler DeletePlaceEvent;
        event EventHandler SavePlaceEvent;
        event EventHandler CancelPlaceEvent;

        void SetPlaceListBindingSource(BindingSource WorkerList);
        void SetProductListBindingSource(BindingSource WorkerList);
    }
}
