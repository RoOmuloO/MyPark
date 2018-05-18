using MyPark.Model.DataBase.Models;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPark.Model.DataBase.Repository
{
    public class EstadiaRepository : RepositoryBase<Estadia>
    {
        public EstadiaRepository (ISession session) : base(session)
        {

        }

        public Estadia BuscarAtivaPelaPlaca(String placa)
        {
            var estadia = Session.Query<Estadia>().FirstOrDefault(f => f.veiculo.Placa == placa 
                                                                    && f.DtSaida == new DateTime());

            return estadia;
        }

        public List<Estadia> BuscarAtivas()
        {
            var estadias = Session.Query<Estadia>().Where(w => w.DtSaida == new DateTime()).ToList();

            return estadias;
        }
    }
}
