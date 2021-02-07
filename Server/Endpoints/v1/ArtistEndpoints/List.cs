using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Server.DomainModel;
using Swashbuckle.AspNetCore.Annotations;

namespace Server.Endpoints.v1.ArtistEndpoints
{
    public class List : BaseAsyncEndpoint
    {
        [HttpGet("/v1/artists")]
        [SwaggerOperation(
            Summary = "List all Artists",
            Description = "List all Artists",
            OperationId = "Artist.List",
            Tags = new[] { "ArtistEndpoint" })
        ]
        public async Task<ActionResult> HandleAsync(
            [FromServices] IAsyncRepository<Artist> repository,
            [FromServices] IMapper mapper,
            [FromQuery] int page = 1, int perPage = 10,
            CancellationToken cancellationToken = default)
        {
            var result = (await repository.ListAllAsync(perPage, page, cancellationToken))
                .Select(i => mapper.Map<ArtistListResult>(i));

            return Ok(result);
        }
    }
}
