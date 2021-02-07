using System;
namespace Sample.Api.DomainModel
{
    public class Album : BaseEntity
    {
        public string Name { get; set; }
        public Guid ArtistId { get; set; }
    }
}
