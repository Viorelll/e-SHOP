using FluentNHibernate.Mapping;

namespace DomainModel.Mapping.Models
{
    using DomainModel.Models;
    class LaptopMap : SubclassMap<Laptop>
    {
        public LaptopMap()
        {
            Map(x => x.LaptopModel).Not.Nullable().Length(30);
            Map(x => x.SistemOperation).Not.Nullable().Length(20);
            Map(x => x.DisplayType).Not.Nullable().Length(10);
            Map(x => x.DisplaySize).Not.Nullable();

            Component(c => c.Resolution, m =>
            {
                m.Map(x => x.Width).Column("ResolutionWidth").Not.Nullable();
                m.Map(x => x.Height).Column("ResolutionHeight").Not.Nullable();

            });

            Map(x => x.ProcessorManufacturer).Not.Nullable().Length(30);
            Map(x => x.ProcessorModel).Not.Nullable().Length(30);
            Map(x => x.ProcessorFrequency).Not.Nullable();
            Map(x => x.MemoryCapacity).Not.Nullable();
            Map(x => x.HDDCapacity).Not.Nullable();
            Map(x => x.Weight).Not.Nullable();
            Map(x => x.VideocardModel).Not.Nullable().Length(50);
            Map(x => x.WifiConnection).Not.Nullable();
            Map(x => x.BluetoothConnection).Not.Nullable();
        }
    }
}



