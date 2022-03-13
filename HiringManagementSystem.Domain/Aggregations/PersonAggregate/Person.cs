using HiringManagementSystem.Domain.Aggregations.TagAggregate;
using HiringManagementSystem.Domain.Frameworks.Base;
using System;
using System.Collections.Generic;

namespace HiringManagementSystem.Domain.Aggregations.PersonAggregate
{
    public class Person : BaseEntityGuid
    {
        public string FirstName { get; set; }
        public string Family { get; set; }
        public string NationalId { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Tag>? Tags { get; set; }
    }
}
