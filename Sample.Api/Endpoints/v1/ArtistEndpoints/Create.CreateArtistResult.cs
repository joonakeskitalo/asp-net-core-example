using System;
namespace Sample.Api.Endpoints.v1.ArtistEndpoints
{
    public class CreateArtistResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ArtistId { get; set; }
    }
}
