using System;

namespace Server.DomainModel
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
