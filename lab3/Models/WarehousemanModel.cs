using DB_course.Models.CompositModels;
using DB_course.Models.DBModels;
using DB_course.Repositories;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Models
{
    public abstract class AWarehousemanModel : IModel
    {
        private IUnitOfWork unitOfWork;
        public IUnitOfWork UnitOfWork { get { return unitOfWork; } }

        public AWarehousemanModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public virtual void DelitUseful(int Id)
        {
            if (Id <= 0) throw new Exception("Invalid Id");
            unitOfWork.UsefulRepository.Delete(Convert.ToString(Id));
            unitOfWork.UsefulRepository.Save();
        }

        public virtual IEnumerable<WarehousemanLookCompose> LookWarehousemanLook()
        {
            return unitOfWork.WarehousemanLookComposeRepository.GetList();
        }

        public virtual IEnumerable<WarehousemanLookCompose> LookWarehousemanLook(string value)
        {

            IEnumerable<WarehousemanLookCompose> personList;
            bool emptyValue = string.IsNullOrWhiteSpace(value);
            if(emptyValue == false)
                personList = unitOfWork.WarehousemanLookComposeRepository.Get(value);
            else
            {
                personList = unitOfWork.WarehousemanLookComposeRepository.GetList();
            }
            return personList;
        }
    }

    public class WarehousemanModel : AWarehousemanModel
    {
        public WarehousemanModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }

    public abstract class AWarehousemanModelDecorator : AWarehousemanModel
    {
        protected AWarehousemanModel workerModel;
        public AWarehousemanModelDecorator(AWarehousemanModel workerModel) : base(workerModel.UnitOfWork)
        {
            this.workerModel = workerModel;
        }
    }

    public class WarehousemanModelLogDecorator : AWarehousemanModelDecorator
    {
        public WarehousemanModelLogDecorator(AWarehousemanModel workerModel) : base(workerModel)
        {

        }


    }
}
