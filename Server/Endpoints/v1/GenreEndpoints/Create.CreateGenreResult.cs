using System;
namespace Server.Endpoints.v1.GenreEndpoints
{
    public class CreateGenreResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
