using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPark.Model.DataBase.Models
{
    public class Plano
    {
        public virtual Guid Id { get; set; }
        public virtual String Titulo { get; set; }
        public virtual String Descricao { get; set; }
        public virtual Boolean Mensal { get; set; }
    }

    public class PlanoMap : ClassMapping<Plano>
    {
        public PlanoMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Guid));

            Property(x => x.Titulo);
            Property(x => x.Descricao);
            Property(x => x.Mensal);
        }
    }

}
