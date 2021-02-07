using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Server.DomainModel;
using Swashbuckle.AspNetCore.Annotations;

namespace Server.Endpoints.v1.UserEndpoints
{
    public class List : BaseAsyncEndpoint
    {
        [HttpGet("/v1/users")]
        [SwaggerOperation(
            Summary = "List all Users",
            Description = "List all Users",
            OperationId = "User.List",
            Tags = new[] { "UserEndpoint" })
        ]
        public async Task<ActionResult> HandleAsync(
            [FromServices] IAsyncRepository<User> repository,
            [FromServices] IMapper mapper,
            [FromQuery] int page = 1, int perPage = 10,
            CancellationToken cancellationToken = default)
        {
            var result = (await repository.ListAllAsync(perPage, page, cancellationToken))
                .Select(i => mapper.Map<UserListResult>(i));

            return Ok(result);
        }
    }
}
