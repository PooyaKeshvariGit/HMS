using System;

namespace HiringManagementSystem.Application.Dtos
{
    public class CreateTagDto
    {
        public string TagName { get; set; }
        public string Description { get; set; }
        public Guid PersonId { get; set; }
    }
}
