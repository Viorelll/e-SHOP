namespace DomainModel.Mapping.Models
{
    using DomainModel.Models;

    public class ItemMap : EntityMap<Item>
    {

        public ItemMap()
        {
             Map(x => x.Name).Not.Nullable();
             Map(x => x.Brand).Not.Nullable();
             Map(x => x.Category).Not.Nullable();
             Map(x => x.Price).Not.Nullable();
             Map(x => x.Description).Nullable();    
        }
    }
}
