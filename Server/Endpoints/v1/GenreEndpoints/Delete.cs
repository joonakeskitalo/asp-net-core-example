using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.DomainModel;
using Swashbuckle.AspNetCore.Annotations;

namespace Server.Endpoints.v1.GenreEndpoints
{
    public class Delete : BaseAsyncEndpoint<Guid, DeleteGenreResult>
    {
        private readonly IAsyncRepository<Genre> _repository;

        public Delete(IAsyncRepository<Genre> repository)
        {
            _repository = repository;
        }

        [HttpDelete("v1/genres/{id}")]
        [SwaggerOperation(
            Summary = "Deletes an Genre",
            Description = "Deletes an Genre",
            OperationId = "Genre.Delete",
            Tags = new[] { "GenreEndpoint" })
        ]
        public override async Task<ActionResult<DeleteGenreResult>> HandleAsync(Guid id, CancellationToken cancellationToken)
        {
            var genre = await _repository.GetByIdAsync(id, cancellationToken);

            if (genre is null)
            {
                return NotFound(id);
            }

            await _repository.DeleteAsync(genre, cancellationToken);
            return Ok(new DeleteGenreResult { DeletedGenreId = id });
        }
    }
}
