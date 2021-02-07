using System;
namespace Server.Endpoints.v1.SongEndpoints
{
    public class UpdateSongCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid AlbumId { get; set; }
    }
}
