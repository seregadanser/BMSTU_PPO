using DB_course.Models.DBModels;
using DB_course.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_course.Models
{
   public enum State{ FIRST, OK, INVALID };
    public abstract class AUnLoginModel  : IModel
    {
        protected IUnitOfWork unitOfWork;
        public IUnitOfWork UnitOfWork { get { return unitOfWork; } }

        public AUnLoginModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public virtual State Check(string login, string password)
        {
            Person p = unitOfWork.personRepository.Get(login).FirstOrDefault();
            if(p == null)
                throw new Exception("Person not found");
            if(p.Password == Hash.HashFunc(password))
            {
                if(p.NumberOfCome == 0)
                    return State.FIRST;
                return State.OK;
            }
            return State.INVALID;
        }

    }

    public class UnLoginModel : AUnLoginModel
    {
        public UnLoginModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
          
        }
    }

    public abstract class AUnLoginModelDecorator : AUnLoginModel
    {
        protected AUnLoginModel workerModel;
        public AUnLoginModelDecorator(AUnLoginModel workerModel) : base(workerModel.UnitOfWork)
        {
            this.workerModel = workerModel;
        }
    }

    public class HUnLoginModelLogDecorator : AUnLoginModelDecorator
    {
        public HUnLoginModelLogDecorator(AUnLoginModel workerModel) : base(workerModel)
        {

        }

        public override State Check(string login, string password)
        {
            State s = base.Check(login, password);
            Console.WriteLine(s);
            return s;
        }

    }
}
