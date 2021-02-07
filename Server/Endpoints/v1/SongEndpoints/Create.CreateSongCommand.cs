using System;
namespace Server.Endpoints.v1.SongEndpoints
{
	public class CreateSongCommand
	{
        public string Name { get; set; }
        public Guid AlbumId { get; set; }
	}
}
