namespace DomainModel.Mapping.Shop
{
    using DomainModel.Shop;
    class OrderMap : EntityMap<Order>
    {
        public OrderMap()
        {
            Map(x => x.ShipTo).Not.Nullable().Length(50);
            Map(x => x.DateCreated).Not.Nullable();
            Map(x => x.DateShipped).Not.Nullable();
            Map(x => x.OrderStatus).Not.Nullable().Length(20);
            References(x => x.Customer).Not.Nullable();
            HasMany(x => x.OrderBuyItems).Inverse().Cascade.All();
        }
    }
}
