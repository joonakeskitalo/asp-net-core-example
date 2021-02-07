using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Server.DomainModel;
using System;
using Swashbuckle.AspNetCore.Annotations;

namespace Server.Endpoints.v1.SongEndpoints
{
    public class Update : BaseAsyncEndpoint<Guid, UpdateSongCommand, UpdateSongResult>
    {
        private readonly IAsyncRepository<Song> _repository;
        private readonly IMapper _mapper;

        public Update(IAsyncRepository<Song> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("/v1/songs/{id}")]
        [SwaggerOperation(
            Summary = "Updates an existing Song",
            Description = "Updates an existing Song",
            OperationId = "Song.Update",
            Tags = new[] { "SongEndpoint" })
        ]
        public override async Task<ActionResult<UpdateSongResult>> HandleAsync(Guid id, [FromBody] UpdateSongCommand request, CancellationToken cancellationToken)
        {
            var song = await _repository.GetByIdAsync(request.Id, cancellationToken);
            _mapper.Map(request, song);
            await _repository.UpdateAsync(song, cancellationToken);
            var result = _mapper.Map<UpdateSongResult>(song);
            return Ok(result);
        }
    }
}
