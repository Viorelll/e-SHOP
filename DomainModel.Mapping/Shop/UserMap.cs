namespace DomainModel.Mapping.Shop
{
    using DomainModel.Shop;
    class UserMap : EntityMap<User>
    {
        public UserMap()
        {
            Map(x => x.Username).Not.Nullable().Length(32);
            Map(x => x.FirstName).Not.Nullable().Length(32);
            Map(x => x.LastName).Not.Nullable().Length(32);
            Map(x => x.Adress).Not.Nullable().Length(50);
            Map(x => x.Email).Not.Nullable().Length(40);
            Map(x => x.Password).Not.Nullable().Length(32);
        }
    }
}
