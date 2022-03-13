using HiringManagementSystem.Domain.Aggregations.PersonAggregate;
using HiringManagementSystem.Domain.Frameworks.Base;
using System;

namespace HiringManagementSystem.Domain.Aggregations.TagAggregate
{
    public class Tag : BaseEntityGuid
    {
        public string TagName { get; set; }
        public string? Description { get; set; }
        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
