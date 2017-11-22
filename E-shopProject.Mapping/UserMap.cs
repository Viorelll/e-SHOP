namespace E_shopProject.Mapping
{
    public class UserMap : EntityShopMap<User>
    {
        public UserMap()
        {
            Map(x => x.Username).Not.Nullable();
            Map(x => x.FirstName).Not.Nullable();
            Map(x => x.LastName).Not.Nullable();
            Map(x => x.Adress).Not.Nullable();
            Map(x => x.Email).Not.Nullable();
            Map(x => x.Password).Not.Nullable();
        }
    }
}
