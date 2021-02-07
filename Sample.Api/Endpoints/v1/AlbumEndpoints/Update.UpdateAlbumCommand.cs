using System;
namespace Sample.Api.Endpoints.v1.AlbumEndpoints
{
    public class UpdateAlbumCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ArtistId { get; set; }
    }
}
