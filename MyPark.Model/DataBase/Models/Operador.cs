using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPark.Model.DataBase.Models
{
    public class Operador
    {
        public virtual Guid Id { get; set; }
        public virtual String Nome { get; set; }
        public virtual DateTime DtAdmissao { get; set; }
        public virtual Boolean Inativo { get; set; }
        public virtual User Usuario { get; set; }
    }

    public class OperadorMap : ClassMapping<Operador>
    {
        public OperadorMap()
        {

            Id(x => x.Id, m => m.Generator(Generators.Guid));

            Property(x => x.Nome);
            Property(x => x.DtAdmissao);
            Property(x => x.Inativo);

            ManyToOne(x => x.Usuario, m =>
            {
                m.Column("idUsuario");
                m.Unique(true);
                //m.NotNullable(true);
                m.Lazy(LazyRelation.NoLazy);
                m.Cascade(Cascade.Persist);
            });
        }
    }
}
