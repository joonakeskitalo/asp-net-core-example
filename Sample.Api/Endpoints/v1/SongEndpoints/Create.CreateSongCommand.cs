using System;
namespace Sample.Api.Endpoints.v1.SongEndpoints
{
	public class CreateSongCommand
	{
        public string Name { get; set; }
        public Guid AlbumId { get; set; }
	}
}
