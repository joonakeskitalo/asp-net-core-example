using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Server.DomainModel;
using System;
using Swashbuckle.AspNetCore.Annotations;

namespace Server.Endpoints.v1.AlbumEndpoints
{
    public class Update : BaseAsyncEndpoint<Guid, UpdateAlbumCommand, UpdateAlbumResult>
    {
        private readonly IAsyncRepository<Album> _repository;
        private readonly IMapper _mapper;

        public Update(IAsyncRepository<Album> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("/v1/albums/{id}")]
        [SwaggerOperation(
            Summary = "Updates an existing Album",
            Description = "Updates an existing Album",
            OperationId = "Album.Update",
            Tags = new[] { "AlbumEndpoint" })
        ]
        public override async Task<ActionResult<UpdateAlbumResult>> HandleAsync(Guid id, [FromBody] UpdateAlbumCommand request, CancellationToken cancellationToken)
        {
            var album = await _repository.GetByIdAsync(request.Id, cancellationToken);
            _mapper.Map(request, album);
            await _repository.UpdateAsync(album, cancellationToken);
            var result = _mapper.Map<UpdateAlbumResult>(album);
            return Ok(result);
        }
    }
}
