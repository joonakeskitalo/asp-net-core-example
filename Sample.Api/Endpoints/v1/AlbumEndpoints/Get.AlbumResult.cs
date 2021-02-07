using System;
namespace Sample.Api.Endpoints.v1.AlbumEndpoints
{
    public class AlbumResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ArtistId { get; set; }
    }
}
