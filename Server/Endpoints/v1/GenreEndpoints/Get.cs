using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.DomainModel;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace Server.Endpoints.v1.GenreEndpoints
{
    public class Get : BaseAsyncEndpoint<Guid, GenreResult>
    {
        private readonly IAsyncRepository<Genre> _repository;
        private readonly IMapper _mapper;

        public Get(IAsyncRepository<Genre> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("/v1/genres/{id}")]
        [SwaggerOperation(
            Summary = "Get a specific Genre",
            Description = "Get a specific Genre",
            OperationId = "Genre.Get",
            Tags = new[] { "GenreEndpoint" })
        ]
        public override async Task<ActionResult<GenreResult>> HandleAsync(Guid id, CancellationToken cancellationToken)
        {
            var genre = await _repository.GetByIdAsync(id, cancellationToken);
            var result = _mapper.Map<GenreResult>(genre);
            return Ok(result);
        }
    }
}
