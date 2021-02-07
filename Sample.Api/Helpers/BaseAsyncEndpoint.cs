﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sample.Api
{
    /// <summary>
    /// A base class for an endpoint that accepts parameters.
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class BaseAsyncEndpoint<TId, TRequest, TResponse> : BaseAsyncEndpoint
    {
        public abstract Task<ActionResult<TResponse>> HandleAsync(TId id, TRequest request, CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// A base class for an endpoint that accepts parameters.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    [ApiController]
    public abstract class BaseAsyncEndpoint<TRequest, TResponse> : BaseAsyncEndpoint
    {
        public abstract Task<ActionResult<TResponse>> HandleAsync(TRequest request, CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// A base class for an endpoint that has no parameters.
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    [ApiController]
    public abstract class BaseAsyncEndpoint<TResponse> : BaseAsyncEndpoint
    {
        public abstract Task<ActionResult<TResponse>> HandleAsync(CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// A base class for all asynchronous endpoints.
    /// </summary>
    [ApiController]
    public abstract class BaseAsyncEndpoint : ControllerBase
    {
    }
}