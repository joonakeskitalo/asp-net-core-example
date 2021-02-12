using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Server.DomainModel;
using Swashbuckle.AspNetCore.Annotations;

namespace Server.Endpoints.v1.GenreEndpoints
{
    public class List : BaseAsyncEndpoint
    {
        [HttpGet("/v1/genres")]
        [SwaggerOperation(
            Summary = "List all Genres",
            Description = "List all Genres",
            OperationId = "Genre.List",
            Tags = new[] { "GenreEndpoint" })
        ]
        public async Task<ActionResult> HandleAsync(
            [FromServices] IAsyncRepository<Genre> repository,
            [FromServices] IMapper mapper,
            [FromQuery] int page = 1, int perPage = 10,
            CancellationToken cancellationToken = default)
        {
            var result = (await repository.ListAllAsync(perPage, page, cancellationToken))
                .Select(i => mapper.Map<GenreListResult>(i));

            return Ok(result);
        }
    }
}
