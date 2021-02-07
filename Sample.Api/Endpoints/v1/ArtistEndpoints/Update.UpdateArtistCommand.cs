using System;
namespace Sample.Api.Endpoints.v1.ArtistEndpoints
{
    public class UpdateArtistCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
