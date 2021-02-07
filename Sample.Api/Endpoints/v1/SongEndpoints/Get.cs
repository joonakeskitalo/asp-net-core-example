using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.Api.DomainModel;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace Sample.Api.Endpoints.v1.SongEndpoints
{
    public class Get : BaseAsyncEndpoint<Guid, SongResult>
    {
        private readonly IAsyncRepository<Song> _repository;
        private readonly IMapper _mapper;

        public Get(IAsyncRepository<Song> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("/v1/songs/{id}")]
        [SwaggerOperation(
            Summary = "Get a specific Song",
            Description = "Get a specific Song",
            OperationId = "Song.Get",
            Tags = new[] { "SongEndpoint" })
        ]
        public override async Task<ActionResult<SongResult>> HandleAsync(Guid id, CancellationToken cancellationToken)
        {
            var song = await _repository.GetByIdAsync(id, cancellationToken);
            var result = _mapper.Map<SongResult>(song);
            return Ok(result);
        }
    }
}
