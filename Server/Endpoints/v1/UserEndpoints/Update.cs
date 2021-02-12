using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using Server.DomainModel;
using System;
using Swashbuckle.AspNetCore.Annotations;

namespace Server.Endpoints.v1.UserEndpoints
{
    public class Update : BaseAsyncEndpoint<Guid, UpdateUserCommand, UpdateUserResult>
    {
        private readonly IAsyncRepository<User> _repository;
        private readonly IMapper _mapper;

        public Update(IAsyncRepository<User> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("/v1/users/{id}")]
        [SwaggerOperation(
            Summary = "Updates an existing User",
            Description = "Updates an existing User",
            OperationId = "User.Update",
            Tags = new[] { "UserEndpoint" })
        ]
        public override async Task<ActionResult<UpdateUserResult>> HandleAsync(Guid id,[FromBody]UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id, cancellationToken);
            user.UpdatedOn = DateTime.UtcNow;
            _mapper.Map(request, user);
            await _repository.UpdateAsync(user, cancellationToken);
            var result = _mapper.Map<UpdateUserResult>(user);
            return Ok(result);
        }
    }
}
