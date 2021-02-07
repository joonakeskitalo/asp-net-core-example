using System;
namespace Sample.Api.Endpoints.v1.SongEndpoints
{
    public class SongListResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid AlbumId { get; set; }
    }
}
