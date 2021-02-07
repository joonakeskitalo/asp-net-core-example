using System;

namespace SampleEndpointApp.DomainModel
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
