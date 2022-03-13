using HiringManagementSystem.Domain.Frameworks.Interfaces;
using System;

namespace HiringManagementSystem.Domain.Frameworks.Base
{
    public class BaseEntityGuid : IEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}
