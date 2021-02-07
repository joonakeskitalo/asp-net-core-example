using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Sample.Api.DomainModel;
using System;

namespace Sample.Api.Endpoints.v1.UserEndpoints
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
        public override async Task<ActionResult<UpdateUserResult>> HandleAsync(Guid id,[FromBody]UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id, cancellationToken);
            _mapper.Map(request, user);
            await _repository.UpdateAsync(user, cancellationToken);
            var result = _mapper.Map<UpdateUserResult>(user);
            return Ok(result);
        }
    }
}
