using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.DomainModel;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace Server.Endpoints.v1.AlbumEndpoints
{
    public class Create : BaseAsyncEndpoint<CreateAlbumCommand, CreateAlbumResult>
    {
        private readonly IAsyncRepository<Album> _repository;
        private readonly IMapper _mapper;

        public Create(IAsyncRepository<Album> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("v1/albums")]
        [SwaggerOperation(
            Summary = "Creates a new Album",
            Description = "Creates a new Album",
            OperationId = "Album.Create",
            Tags = new[] { "AlbumEndpoint" })
        ]
        public override async Task<ActionResult<CreateAlbumResult>> HandleAsync([FromBody] CreateAlbumCommand request, CancellationToken cancellationToken)
        {
            var album = new Album
            {
                Id = Guid.NewGuid()
            };
            _mapper.Map(request, album);
            await _repository.AddAsync(album, cancellationToken);
            var result = _mapper.Map<CreateAlbumResult>(album);
            return Ok(result);
        }
    }
}
