using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.Api.DomainModel;
using Swashbuckle.AspNetCore.Annotations;

namespace Sample.Api.Endpoints.v1.UserEndpoints
{
    public class Delete : BaseAsyncEndpoint<Guid, DeleteUserResult>
    {
        private readonly IAsyncRepository<User> _repository;

        public Delete(IAsyncRepository<User> repository)
        {
            _repository = repository;
        }

        [HttpDelete("v1/users/{id}")]
        [SwaggerOperation(
            Summary = "Deletes an User",
            Description = "Deletes an User",
            OperationId = "User.Delete",
            Tags = new[] { "UserEndpoint" })
        ]
        public override async Task<ActionResult<DeleteUserResult>> HandleAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(id, cancellationToken);

            if (user is null)
            {
                return NotFound(id);
            }

            await _repository.DeleteAsync(user, cancellationToken);
            return Ok(new DeleteUserResult { DeletedUserId = id });
        }
    }
}
