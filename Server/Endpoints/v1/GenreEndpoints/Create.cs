using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.DomainModel;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace Server.Endpoints.v1.GenreEndpoints
{
    public class Create : BaseAsyncEndpoint<CreateGenreCommand, CreateGenreResult>
    {
        private readonly IAsyncRepository<Genre> _repository;
        private readonly IMapper _mapper;

        public Create(IAsyncRepository<Genre> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("v1/genres")]
        [SwaggerOperation(
            Summary = "Creates a new Genre",
            Description = "Creates a new Genre",
            OperationId = "Genre.Create",
            Tags = new[] { "GenreEndpoint" })
        ]
        public override async Task<ActionResult<CreateGenreResult>> HandleAsync([FromBody] CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = new Genre
            {
                Id = Guid.NewGuid()
            };
            _mapper.Map(request, genre);
            await _repository.AddAsync(genre, cancellationToken);
            var result = _mapper.Map<CreateGenreResult>(genre);
            return Ok(result);
        }
    }
}
