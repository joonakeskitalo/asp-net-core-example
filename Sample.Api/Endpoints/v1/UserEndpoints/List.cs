using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Sample.Api.DomainModel;

namespace Sample.Api.Endpoints.v1.UserEndpoints
{
    public class List : BaseAsyncEndpoint
    {
        [HttpGet("/v1/users")]
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
