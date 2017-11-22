using FluentNHibernate.Mapping;

namespace DomainModel.Mapping.Models
{
    using DomainModel.Models;
    class CPUMap : SubclassMap<CPU>
    {
        public CPUMap()
        {
            Map(x => x.CpuModel).Not.Nullable();
            Map(x => x.FamilyName).Not.Nullable().Length(30);
            Map(x => x.Frequency).Not.Nullable();
        }
    }
}


