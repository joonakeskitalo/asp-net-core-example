using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Server.DomainModel;
using System;
using Swashbuckle.AspNetCore.Annotations;

namespace Server.Endpoints.v1.GenreEndpoints
{
    public class Update : BaseAsyncEndpoint<Guid, UpdateGenreCommand, UpdateGenreResult>
    {
        private readonly IAsyncRepository<Genre> _repository;
        private readonly IMapper _mapper;

        public Update(IAsyncRepository<Genre> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("/v1/genres/{id}")]
        [SwaggerOperation(
            Summary = "Updates an existing Genre",
            Description = "Updates an existing Genre",
            OperationId = "Genre.Update",
            Tags = new[] { "GenreEndpoint" })
        ]
        public override async Task<ActionResult<UpdateGenreResult>> HandleAsync(Guid id, [FromBody] UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _repository.GetByIdAsync(request.Id, cancellationToken);
            _mapper.Map(request, genre);
            await _repository.UpdateAsync(genre, cancellationToken);
            var result = _mapper.Map<UpdateGenreResult>(genre);
            return Ok(result);
        }
    }
}
