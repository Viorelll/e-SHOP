using FluentNHibernate.Mapping;

namespace DomainModel.Mapping.Models
{
    using DomainModel.Models;

    class MotherboardMap : SubclassMap<Motherboard>
    {
        public MotherboardMap()
        {
            Map(x => x.MbModel).Not.Nullable().Length(30);
            Map(x => x.Format).Not.Nullable().Length(10);
            Map(x => x.ProcessorSocket).Not.Nullable().Length(15);
            Map(x => x.ProcessorManufacturer).Not.Nullable().Length(30);
            Map(x => x.HDDInterface).Not.Nullable().Length(30);
            Map(x => x.MemoryType).Not.Nullable().Length(10);
            Map(x => x.VideoConnection).Not.Nullable();
            Map(x => x.AudioConnection).Not.Nullable();
        }
    }
}



