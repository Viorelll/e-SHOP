using FluentNHibernate.Mapping;

namespace DomainModel.Mapping.Models
{
    using DomainModel.Models;

    class WebcamMap : SubclassMap<Webcam>
    {
        public WebcamMap()
        {
            Map(x => x.WebcamModel).Not.Nullable().Length(30);
            Map(x => x.WebcamInterface).Not.Nullable().Length(30);
            Map(x => x.Pixels).Not.Nullable();

            Component(c => c.VideoResolution, m =>
            {
                m.Map(x => x.Width).Column("VideoWidth").Not.Nullable();
                m.Map(x => x.Height).Column("VideoHeight").Not.Nullable();

            });

            Component(c => c.PhotoResolution, m =>
            {
                m.Map(x => x.Width).Column("PhotoWidth").Not.Nullable();
                m.Map(x => x.Height).Column("PhotoHeight").Not.Nullable();
            });

        }
    }
}


