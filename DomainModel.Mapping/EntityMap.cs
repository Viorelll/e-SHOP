using DomainModel.Models;
using FluentNHibernate.Mapping;

namespace DomainModel.Mapping
{

    public abstract class EntityMap<TEntity> : ClassMap<TEntity> where TEntity : Entity
    {
        protected EntityMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("1000");
            DynamicUpdate();
        }
    }
}
