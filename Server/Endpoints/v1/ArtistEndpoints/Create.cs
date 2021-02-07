using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.DomainModel;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace Server.Endpoints.v1.ArtistEndpoints
{
    public class Create : BaseAsyncEndpoint<CreateArtistCommand, CreateArtistResult>
    {
        private readonly IAsyncRepository<Artist> _repository;
        private readonly IMapper _mapper;

        public Create(IAsyncRepository<Artist> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("v1/artists")]
        [SwaggerOperation(
            Summary = "Creates a new Artist",
            Description = "Creates a new Artist",
            OperationId = "Artist.Create",
            Tags = new[] { "ArtistEndpoint" })
        ]
        public override async Task<ActionResult<CreateArtistResult>> HandleAsync([FromBody] CreateArtistCommand request, CancellationToken cancellationToken)
        {
            var artist = new Artist
            {
                Id = Guid.NewGuid()
            };
            _mapper.Map(request, artist);
            await _repository.AddAsync(artist, cancellationToken);
            var result = _mapper.Map<CreateArtistResult>(artist);
            return Ok(result);
        }
    }
}
