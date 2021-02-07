using System;
namespace Server.Endpoints.v1.ArtistEndpoints
{
    public class CreateArtistResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
