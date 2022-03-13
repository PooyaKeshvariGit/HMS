using System;

namespace HiringManagementSystem.Application.Dtos
{
    public class TagDto
    {
        public Guid Id { get; set; }
        public string TagName { get; set; }
        public string Description { get; set; }
        public Guid PersonId { get; set; }
    }
}
