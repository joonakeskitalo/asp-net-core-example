using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Sample.Api.DomainModel;
using Swashbuckle.AspNetCore.Annotations;

namespace Sample.Api.Endpoints.v1.AlbumEndpoints
{
    public class List : BaseAsyncEndpoint
    {
        [HttpGet("/v1/albums")]
        [SwaggerOperation(
            Summary = "List all Albums",
            Description = "List all Albums",
            OperationId = "Album.List",
            Tags = new[] { "AlbumEndpoint" })
        ]
        public async Task<ActionResult> HandleAsync(
            [FromServices] IAsyncRepository<Album> repository,
            [FromServices] IMapper mapper,
            [FromQuery] int page = 1, int perPage = 10,
            CancellationToken cancellationToken = default)
        {
            var result = (await repository.ListAllAsync(perPage, page, cancellationToken))
                .Select(i => mapper.Map<AlbumListResult>(i));

            return Ok(result);
        }
    }
}
