using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.DomainModel;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace Server.Endpoints.v1.SongEndpoints
{
    public class Create : BaseAsyncEndpoint<CreateSongCommand, CreateSongResult>
    {
        private readonly IAsyncRepository<Song> _repository;
        private readonly IMapper _mapper;

        public Create(IAsyncRepository<Song> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("v1/songs")]
        [SwaggerOperation(
            Summary = "Creates a new Song",
            Description = "Creates a new Song",
            OperationId = "Song.Create",
            Tags = new[] { "SongEndpoint" })
        ]
        public override async Task<ActionResult<CreateSongResult>> HandleAsync([FromBody] CreateSongCommand request, CancellationToken cancellationToken)
        {
            var song = new Song
            {
                Id = Guid.NewGuid()
            };
            _mapper.Map(request, song);
            await _repository.AddAsync(song, cancellationToken);
            var result = _mapper.Map<CreateSongResult>(song);
            return Ok(result);
        }
    }
}
