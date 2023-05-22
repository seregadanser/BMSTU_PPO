
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

        public string Proffesion { get; set; }

        public AUnLoginModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public virtual State Check(string login, string password)
        {
            Person p = unitOfWork.PersonRepository.Get(login).FirstOrDefault() ?? throw new Exception("Person not found");
            if(p.Password == Hash.HashFunc(password))
            {
                Proffesion = p.Position;
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
        protected readonly ILogger<AUnLoginModel> logger;
        public AUnLoginModelDecorator(AUnLoginModel workerModel, ILoggerFactory loggerFactory) : base(workerModel.UnitOfWork)
        {
            this.workerModel = workerModel;
            logger = loggerFactory.CreateLogger<AUnLoginModel>();
        }
  
    }

    public class UnLoginModelLogDecorator : AUnLoginModelDecorator
    {
        public UnLoginModelLogDecorator(AUnLoginModel workerModel, ILoggerFactory loggerFactory) : base(workerModel,loggerFactory)
        {

        }

        public override State Check(string login, string password)
        {
            State s = State.INVALID;
            try
            {
                s = workerModel.Check(login, password);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw ex;
            }
            this.Proffesion = workerModel.Proffesion;
            logger.LogInformation($"Login {login} checked {s}");

            return s;
        }

    }
}
