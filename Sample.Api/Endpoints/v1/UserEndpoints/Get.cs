using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.Api.DomainModel;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace Sample.Api.Endpoints.v1.UserEndpoints
{
    public class Get : BaseAsyncEndpoint<Guid, UserResult>
    {
        private readonly IAsyncRepository<User> _repository;
        private readonly IMapper _mapper;

        public Get(IAsyncRepository<User> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("/v1/users/{id}")]
        [SwaggerOperation(
            Summary = "Get a specific User",
            Description = "Get a specific User",
            OperationId = "User.Get",
            Tags = new[] { "UserEndpoint" })
        ]
        public override async Task<ActionResult<UserResult>> HandleAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(id, cancellationToken);
            var result = _mapper.Map<UserResult>(user);
            return Ok(result);
        }
    }
}
