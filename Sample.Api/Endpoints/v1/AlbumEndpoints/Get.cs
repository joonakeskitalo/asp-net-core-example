using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.Api.DomainModel;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;

namespace Sample.Api.Endpoints.v1.AlbumEndpoints
{
    public class Get : BaseAsyncEndpoint<Guid, AlbumResult>
    {
        private readonly IAsyncRepository<Album> _repository;
        private readonly IMapper _mapper;

        public Get(IAsyncRepository<Album> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("/v1/albums/{id}")]
        [SwaggerOperation(
            Summary = "Get a specific Album",
            Description = "Get a specific Album",
            OperationId = "Album.Get",
            Tags = new[] { "AlbumEndpoint" })
        ]
        public override async Task<ActionResult<AlbumResult>> HandleAsync(Guid id, CancellationToken cancellationToken)
        {
            var album = await _repository.GetByIdAsync(id, cancellationToken);
            var result = _mapper.Map<AlbumResult>(album);
            return Ok(result);
        }
    }
}
