using FluentNHibernate.Mapping;

namespace DomainModel.Mapping.Models
{

    using DomainModel.Models;
    class RamMap : SubclassMap<RAM>
    {
        public RamMap()
        {
            Map(x => x.Type).Not.Nullable().Length(10);
            Map(x => x.Capacity).Not.Nullable();
            Map(x => x.Frequency).Not.Nullable();
        }
    }
}




