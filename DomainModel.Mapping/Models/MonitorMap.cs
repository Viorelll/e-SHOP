using FluentNHibernate.Mapping;

namespace DomainModel.Mapping.Models
{
    using DomainModel.Models;

    class MonitorMap : SubclassMap<Monitor>
    {
        public MonitorMap()
        {
            Map(x => x.DisplaySize).Not.Nullable();
            Map(x => x.DisplayType).Not.Nullable().Length(10);
            Map(x => x.MonitorModel).Not.Nullable().Length(30);
        }

    }
}
