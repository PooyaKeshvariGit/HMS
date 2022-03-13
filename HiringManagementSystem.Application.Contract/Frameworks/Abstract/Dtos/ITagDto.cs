using System;

namespace HiringManagementSystem.Application.Contract.Frameworks.Abstract.Dtos
{
    public interface ITagDto
    {
        string TagName { get; set; }
        string Description { get; set; }
        Guid PersonId { get; set; }
    }
}
