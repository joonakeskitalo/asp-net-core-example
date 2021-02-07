using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.DomainModel;
using Swashbuckle.AspNetCore.Annotations;

namespace Server.Endpoints.v1.AlbumEndpoints
{
    public class Delete : BaseAsyncEndpoint<Guid, DeleteAlbumResult>
    {
        private readonly IAsyncRepository<Album> _repository;

        public Delete(IAsyncRepository<Album> repository)
        {
            _repository = repository;
        }

        [HttpDelete("v1/albums/{id}")]
        [SwaggerOperation(
            Summary = "Deletes an Album",
            Description = "Deletes an Album",
            OperationId = "Album.Delete",
            Tags = new[] { "AlbumEndpoint" })
        ]
        public override async Task<ActionResult<DeleteAlbumResult>> HandleAsync(Guid id, CancellationToken cancellationToken)
        {
            var album = await _repository.GetByIdAsync(id, cancellationToken);

            if (album is null)
            {
                return NotFound(id);
            }

            await _repository.DeleteAsync(album, cancellationToken);
            return Ok(new DeleteAlbumResult { DeletedAlbumId = id });
        }
    }
}
