using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.Api.DomainModel;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace Sample.Api.Endpoints.v1.ArtistEndpoints
{
    public class Get : BaseAsyncEndpoint<Guid, ArtistResult>
    {
        private readonly IAsyncRepository<Artist> _repository;
        private readonly IMapper _mapper;

        public Get(IAsyncRepository<Artist> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("/v1/artists/{id}")]
        [SwaggerOperation(
            Summary = "Get a specific Artist",
            Description = "Get a specific Artist",
            OperationId = "Artist.Get",
            Tags = new[] { "ArtistEndpoint" })
        ]
        public override async Task<ActionResult<ArtistResult>> HandleAsync(Guid id, CancellationToken cancellationToken)
        {
            var artist = await _repository.GetByIdAsync(id, cancellationToken);
            var result = _mapper.Map<ArtistResult>(artist);
            return Ok(result);
        }
    }
}
