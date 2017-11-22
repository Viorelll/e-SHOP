using FluentNHibernate.Mapping;

namespace DomainModel.Mapping.Shop
{
    using DomainModel.Shop;
    class CustomerMap : SubclassMap<Customer>
    {
        public CustomerMap()
        {
            HasMany(x => x.CustomOrder).Inverse().Cascade.All();
        }
    }
}
