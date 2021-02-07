using System;
namespace Server.Endpoints.v1.AlbumEndpoints
{
	public class CreateAlbumCommand
	{
        public string Name { get; set; }
        public Guid ArtistId { get; set; }
	}
}
