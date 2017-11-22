using FluentNHibernate.Mapping;

namespace DomainModel.Mapping.Models
{

    using DomainModel.Models;

    class MouseMap : SubclassMap<Mouse>
    {
        public MouseMap()
        {
            Map(x => x.MouseModel).Not.Nullable().Length(30);
            Map(x => x.Type).Not.Nullable().Length(10);
            Map(x => x.Dpi).Not.Nullable();
        }
    }
}




