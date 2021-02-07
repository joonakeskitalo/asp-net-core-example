using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.DomainModel;
using Swashbuckle.AspNetCore.Annotations;

namespace Server.Endpoints.v1.SongEndpoints
{
    public class Delete : BaseAsyncEndpoint<Guid, DeleteSongResult>
    {
        private readonly IAsyncRepository<Song> _repository;

        public Delete(IAsyncRepository<Song> repository)
        {
            _repository = repository;
        }

        [HttpDelete("v1/songs/{id}")]
        [SwaggerOperation(
            Summary = "Deletes an Song",
            Description = "Deletes an Song",
            OperationId = "Song.Delete",
            Tags = new[] { "SongEndpoint" })
        ]
        public override async Task<ActionResult<DeleteSongResult>> HandleAsync(Guid id, CancellationToken cancellationToken)
        {
            var song = await _repository.GetByIdAsync(id, cancellationToken);

            if (song is null)
            {
                return NotFound(id);
            }

            await _repository.DeleteAsync(song, cancellationToken);
            return Ok(new DeleteSongResult { DeletedSongId = id });
        }
    }
}
