using FluentNHibernate.Mapping;

namespace DomainModel.Mapping.Models
{

    using DomainModel.Models;
    class KeyboardMap : SubclassMap<Keyboard>
    {
        public KeyboardMap()
        {
            Map(x => x.KeyboardModel).Not.Nullable().Length(30);
            Map(x => x.Type).Not.Nullable().Length(10);
            Map(x => x.KeyboardInterface).Not.Nullable().Length(10);
        }
    }
}
