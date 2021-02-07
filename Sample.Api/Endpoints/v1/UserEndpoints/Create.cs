using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.Api.DomainModel;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace Sample.Api.Endpoints.v1.UserEndpoints
{
    public class Create : BaseAsyncEndpoint<CreateUserCommand, CreateUserResult>
    {
        private readonly IAsyncRepository<User> _repository;
        private readonly IMapper _mapper;

        public Create(IAsyncRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("v1/users")]
        [SwaggerOperation(
            Summary = "Creates a new User",
            Description = "Creates a new User",
            OperationId = "User.Create",
            Tags = new[] { "UserEndpoint" })
        ]
        public override async Task<ActionResult<CreateUserResult>> HandleAsync([FromBody] CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = Guid.NewGuid()
            };
            _mapper.Map(request, user);
            await _repository.AddAsync(user, cancellationToken);
            var result = _mapper.Map<CreateUserResult>(user);
            return Ok(result);
        }
    }
}
