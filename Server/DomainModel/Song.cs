using System;

namespace Server.DomainModel
{
    public class Song : BaseEntity
    {
        public string Name { get; set; }
        public Guid AlbumId { get; set; }
        public Guid ArtistId { get; set; }
    }
}
