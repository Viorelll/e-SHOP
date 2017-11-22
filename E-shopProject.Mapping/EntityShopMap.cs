namespace E_shopProject.Mapping
{
    using FluentNHibernate.Mapping;
    public abstract class EntityShopMap<TEntity> : ClassMap<TEntity> where TEntity : EntityShop
    {
        protected EntityShopMap()
        {
            Id(x => x.Id).GeneratedBy.HiLo("1000");

            DynamicUpdate();
        }
    }
}
