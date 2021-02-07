using System;
namespace Sample.Api.Endpoints.v1.AlbumEndpoints
{
	public class CreateAlbumCommand
	{
        public string Name { get; set; }
        public Guid ArtistId { get; set; }
	}
}
