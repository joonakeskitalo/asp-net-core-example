using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Server.DomainModel;
using System;
using Swashbuckle.AspNetCore.Annotations;

namespace Server.Endpoints.v1.ArtistEndpoints
{
    public class Update : BaseAsyncEndpoint<Guid, UpdateArtistCommand, UpdateArtistResult>
    {
        private readonly IAsyncRepository<Artist> _repository;
        private readonly IMapper _mapper;

        public Update(IAsyncRepository<Artist> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("/v1/artists/{id}")]
        [SwaggerOperation(
            Summary = "Updates an existing Artist",
            Description = "Updates an existing Artist",
            OperationId = "Artist.Update",
            Tags = new[] { "ArtistEndpoint" })
        ]
        public override async Task<ActionResult<UpdateArtistResult>> HandleAsync(Guid id, [FromBody] UpdateArtistCommand request, CancellationToken cancellationToken)
        {
            var artist = await _repository.GetByIdAsync(request.Id, cancellationToken);
            _mapper.Map(request, artist);
            await _repository.UpdateAsync(artist, cancellationToken);
            var result = _mapper.Map<UpdateArtistResult>(artist);
            return Ok(result);
        }
    }
}
