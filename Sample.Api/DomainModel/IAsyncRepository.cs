using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SampleEndpointApp.DomainModel;

namespace Sample.Api.DomainModel
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken);

        Task<IReadOnlyList<T>> ListAllAsync(int perPage, int page, CancellationToken cancellationToken);

        Task<T> AddAsync(T entity, CancellationToken cancellationToken);

        Task UpdateAsync(T entity, CancellationToken cancellationToken);

        Task DeleteAsync(T entity, CancellationToken cancellationToken);
    }
}
