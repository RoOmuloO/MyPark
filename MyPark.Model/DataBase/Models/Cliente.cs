using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPark.Model.DataBase.Models
{
    public class Cliente
    {
        public virtual Guid Id { get; set; }
        public virtual String Nome { get; set; }
        public virtual String CPF { get; set; }
        public virtual Double CNH { get; set; }
        public virtual DateTime DtNascimento { get; set; }
        public virtual Boolean Inativo { get; set; }
    }

    public class ClienteMap : ClassMapping<Cliente>
    {
        public ClienteMap()
        {

            Id(x => x.Id, m => m.Generator(Generators.Guid));

            Property(x => x.Nome);
            Property(x => x.CPF);
            Property(x => x.CNH);
            Property(x => x.DtNascimento);
            Property(x => x.Inativo);
        }
    }
}
