using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.DomainModel;
using Swashbuckle.AspNetCore.Annotations;

namespace Server.Endpoints.v1.ArtistEndpoints
{
    public class Delete : BaseAsyncEndpoint<Guid, DeleteArtistResult>
    {
        private readonly IAsyncRepository<Artist> _repository;

        public Delete(IAsyncRepository<Artist> repository)
        {
            _repository = repository;
        }

        [HttpDelete("v1/artists/{id}")]
        [SwaggerOperation(
            Summary = "Deletes an Artist",
            Description = "Deletes an Artist",
            OperationId = "Artist.Delete",
            Tags = new[] { "ArtistEndpoint" })
        ]
        public override async Task<ActionResult<DeleteArtistResult>> HandleAsync(Guid id, CancellationToken cancellationToken)
        {
            var artist = await _repository.GetByIdAsync(id, cancellationToken);

            if (artist is null)
            {
                return NotFound(id);
            }

            await _repository.DeleteAsync(artist, cancellationToken);
            return Ok(new DeleteArtistResult { DeletedArtistId = id });
        }
    }
}
