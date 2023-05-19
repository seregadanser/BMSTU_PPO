using DB_course.Models.DBModels;
using DB_course.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace DB_course.Models
{
    public abstract class AHRAdminModel : IModel
    {
        protected IUnitOfWork unitOfWork;
        public IUnitOfWork UnitOfWork { get { return unitOfWork; } }


        public AHRAdminModel(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }
        public virtual void AddPerson(Person person)
        {
            new DataValidateModel().Validate(person);
            unitOfWork.PersonRepository.Create(person);
            unitOfWork.PersonRepository.Save();
 
        }

        public virtual void RemovePerson(string Id)
        {
            IEnumerable<Useful> u = unitOfWork.UsefulRepository.GetList();
            foreach (Useful useful in u)
                if (useful.PersonId == Id)
                    throw new Exception("Person in useful");
            unitOfWork.PersonRepository.Delete(Id);
            unitOfWork.PersonRepository.Save();
        }

        public virtual void UpdatePerson(string Id_cur, Person updateperson)
        {
            new DataValidateModel().Validate(updateperson);
            Person curperson = null;
            try
            {
                curperson = unitOfWork.PersonRepository.Get(Id_cur).First();
                if(curperson == null)
                    throw new NoSuchObjectException("No such person for update");
            }
            catch { return; }
            curperson.Position = updateperson.Position;
            curperson.Name = updateperson.Name;
            curperson.SecondName = updateperson.SecondName;
            curperson.DateOfBirthday = updateperson.DateOfBirthday;
            unitOfWork.PersonRepository.Update(curperson);
            unitOfWork.PersonRepository.Save();
        }

        public virtual IEnumerable<Person> LookPerson()
        {
            return unitOfWork.PersonRepository.GetList();
        }

        public virtual IEnumerable<Person> LookPerson(string value)
        {
            
            IEnumerable<Person> personList;
            bool emptyValue = string.IsNullOrWhiteSpace(value);
            if (emptyValue == false)
                personList = unitOfWork.PersonRepository.Get(value);
            else {
                personList = unitOfWork.PersonRepository.GetList(); }
            return personList;
        }
    }

    public class HRAdminModel : AHRAdminModel
    {
        public HRAdminModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }

    public abstract class AHRAdminModelDecorator : AHRAdminModel
    {
        protected AHRAdminModel workerModel;
        protected readonly ILogger<AHRAdminModel> logger;
        public AHRAdminModelDecorator(AHRAdminModel workerModel, ILoggerFactory loggerFactory) : base(workerModel.UnitOfWork)
        {
            this.workerModel = workerModel;
            logger = loggerFactory.CreateLogger<AHRAdminModel>();
        }
    }

    public class HRAdminModelDecorator : AHRAdminModelDecorator
    {
        public HRAdminModelDecorator(AHRAdminModel workerModel, ILoggerFactory loggerFactory) : base(workerModel, loggerFactory)
        {

        }

        public override void AddPerson(Person person)
        {
            try
            {
                workerModel.AddPerson(person);
            }
            catch(Exception ex) {
                logger.LogError(ex.Message);
                throw ex;
            }
            logger.LogInformation($"Person {person.Login} added succed");
        }
        public override void RemovePerson(string Id)
        {
            try
            {
                workerModel.RemovePerson(Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw ex;
            }
            logger.LogInformation($"Person {Id} removed succed");
        }
        public override void UpdatePerson(string Id_cur, Person updateperson)
        {
            try
            {
                workerModel.UpdatePerson(Id_cur, updateperson); 
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw ex;
            }
            logger.LogInformation($"Person {Id_cur} updated succed");
        }
    }
}
