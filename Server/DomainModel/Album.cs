using System;
namespace Server.DomainModel
{
    public class Album : BaseEntity
    {
        public string Name { get; set; }
        public Guid ArtistId { get; set; }
    }
}
