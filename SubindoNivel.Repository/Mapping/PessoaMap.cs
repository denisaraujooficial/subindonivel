using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using SubindoNivel.Entity.Entities;

namespace SubindoNivel.Repository.Mapping
{
    public class PessoaMap : ClassMapping<Pessoa>
    {
        public PessoaMap()
        {
            Id(i => i.Id, x =>
            {
                x.Generator(Generators.Increment);
                x.Type(NHibernateUtil.Int64);
                //x.Column("Id");               
            });

            Property(b => b.Nome, x =>
            {
                x.Length(30);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);                
            });

            Property(b => b.Idade, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });

            Table("pessoa");
        }

    }
}
