using System;

namespace Sample.Api.DomainModel
{
    public class Song : BaseEntity
    {
        public string Name { get; set; }
        public Guid AlbumId { get; set; }
        public Guid ArtistId { get; set; }
    }
}
