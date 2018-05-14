using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPark.Model.DataBase.Models
{
    public class Veiculo
    {
        public virtual String Placa { get; set; }
        public virtual String Marca { get; set; }
        public virtual String Modelo { get; set; }
        public virtual String Cor { get; set; }
        public virtual TipoVeiculo Tipo { get; set; }
        public virtual IList<Estadia> estadias { get; set; }

        public Veiculo()
        {
            estadias = new List<Estadia>();
        }
    }

    public class VeiculoMap : ClassMapping<Veiculo>
    {
        public VeiculoMap()
        {
            
            Id(x => x.Placa);
            Property(x => x.Marca);
            Property(x => x.Modelo);
            Property(x => x.Cor);

            //Exemplo N:1
            ManyToOne(x => x.Tipo, m =>
            {
                m.Column("IdTipo");
                m.Lazy(LazyRelation.NoLazy);
            });

            Bag(x => x.estadias, m =>
           {
               m.Cascade(Cascade.All);
               m.Lazy(CollectionLazy.NoLazy);
               m.Inverse(true);
               m.Key(k => k.Column("idVeiculo"));

           }, r => r.OneToMany());

        }
    }
}
