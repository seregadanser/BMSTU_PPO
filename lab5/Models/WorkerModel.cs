using DB_course.Models.CompositModels;
using DB_course.Models.DBModels;
using DB_course.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Models
{
    public abstract class AWorkerModel : IModel
    {
        protected private IUnitOfWork unitOfWork;
        protected string curId = "";

        public IUnitOfWork UnitOfWork { get { return unitOfWork;  } }
        public string CurrentLogin { get { return curId; } }

        public AWorkerModel(IUnitOfWork unitOfWork, string login)
        {
            this.unitOfWork = unitOfWork;
            this.curId = login;
        }

        public virtual void DelitUseful(int Id)
        {
            if (Id <= 0) throw new IdException("Invalid Id");
            unitOfWork.UsefulRepository.Delete(Convert.ToString(Id));
            unitOfWork.UsefulRepository.Save();
        }
        public virtual void AddUseful(WorkerLookCompose value)
        {
            Useful u = new Useful();
            u.PersonId = curId;
            u.InventoryId = value.Inventory_number;
            u.DateOfStart = DateTime.Now;
            new DataValidateModel().Validate(u);
            unitOfWork.UsefulRepository.Create(u);
            unitOfWork.UsefulRepository.Save();
        }
        public virtual void UpdatePasswoord(string newpassword)
        {
            Person curperson = null;
            try
            {
                curperson = unitOfWork.PersonRepository.Get(curId).First();
                if (curperson == null)
                    throw new NoSuchObjectException("No such person for update");
            }
            catch { return; }
            curperson.Password = newpassword;
            curperson.NumberOfCome = curperson.NumberOfCome + 1;
            new DataValidateModel().Validate(curperson);
            unitOfWork.PersonRepository.Update(curperson);
            unitOfWork.PersonRepository.Save();
        }
        public virtual IEnumerable<WorkerLookCompose> LookProducts() 
        {
            return unitOfWork.WorkerLookComposeRepository.GetList(); 
        }
        public virtual IEnumerable<WorkerLookCompose> LookProducts(string value)
        {
            IEnumerable<WorkerLookCompose> personList;
            bool emptyValue = string.IsNullOrWhiteSpace(value);
            if (emptyValue == false)
                personList = unitOfWork.WorkerLookComposeRepository.Get(value);
            else
            {
                personList = unitOfWork.WorkerLookComposeRepository.GetList();
            }
            return personList;
        }
        public virtual IEnumerable<WorkerLookUsefulCompose> LookUsing() 
        { 
            return unitOfWork.WorkerLookUsefulComposeRepository.Get(Convert.ToString(curId)); 
        }

    }

    public class WorkerModel : AWorkerModel
    {

        public WorkerModel(IUnitOfWork unitOfWork, string login) : base(unitOfWork, login)
        {

        }
    }

    public abstract class AWorkerModelDecorator : AWorkerModel
    {
        protected AWorkerModel workerModel;
        public AWorkerModelDecorator(AWorkerModel workerModel) : base(workerModel.UnitOfWork, workerModel.CurrentLogin)
        {
            this.workerModel = workerModel;
        }
    }

    public class WorkerModelLogDecorator : AWorkerModelDecorator
    {
        public WorkerModelLogDecorator (AWorkerModel workerModel) : base(workerModel)
        {

        }

        public override void AddUseful(WorkerLookCompose value)
        {
            base.AddUseful(value);
            Console.WriteLine("Add useful at " + DateTime.Now);
        }
    }
}
