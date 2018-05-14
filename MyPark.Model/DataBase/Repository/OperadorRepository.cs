using MyPark.Model.DataBase.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPark.Model.DataBase.Repository
{
    public class OperadorRepository : RepositoryBase<Operador>
    {
        public OperadorRepository (ISession session) : base(session) { }
    }
}
