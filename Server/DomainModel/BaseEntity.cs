using System;
using System.ComponentModel.DataAnnotations;

namespace Server.DomainModel
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
