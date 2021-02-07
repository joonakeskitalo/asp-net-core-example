using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Sample.Api.DomainModel;
using Swashbuckle.AspNetCore.Annotations;

namespace Sample.Api.Endpoints.v1.SongEndpoints
{
    public class List : BaseAsyncEndpoint
    {
        [HttpGet("/v1/songs")]
        [SwaggerOperation(
            Summary = "List all Songs",
            Description = "List all Songs",
            OperationId = "Song.List",
            Tags = new[] { "SongEndpoint" })
        ]
        public async Task<ActionResult> HandleAsync(
            [FromServices] IAsyncRepository<Song> repository,
            [FromServices] IMapper mapper,
            [FromQuery] int page = 1, int perPage = 10,
            CancellationToken cancellationToken = default)
        {
            var result = (await repository.ListAllAsync(perPage, page, cancellationToken))
                .Select(i => mapper.Map<SongListResult>(i));

            return Ok(result);
        }
    }
}
