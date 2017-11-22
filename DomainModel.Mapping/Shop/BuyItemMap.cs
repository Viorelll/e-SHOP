namespace DomainModel.Mapping.Shop
{
    using DomainModel.Shop;
    class BuyItemMap : EntityMap<BuyItem>
    {
        public BuyItemMap()
        {
            Map(x => x.Quantity).Not.Nullable();
            References(x => x.Item).Not.Nullable();
            References(x => x.Order).Not.Nullable();
        }
    }
}
