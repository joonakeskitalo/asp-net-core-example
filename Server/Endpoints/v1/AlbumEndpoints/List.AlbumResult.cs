using System;
namespace Server.Endpoints.v1.AlbumEndpoints
{
    public class AlbumListResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ArtistId { get; set; }
    }
}
