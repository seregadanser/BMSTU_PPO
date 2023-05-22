using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_course.Repositories;

namespace DB_course.Models
{
    public interface IModel
    {
        public IUnitOfWork UnitOfWork { get; }
    }
}
