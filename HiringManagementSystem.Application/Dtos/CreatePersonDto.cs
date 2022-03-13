using System;
using System.Collections.Generic;

namespace HiringManagementSystem.Application.Dtos
{
    public class CreatePersonDto
    {
        public string FirstName { get; set; }
        public string Family { get; set; }
        public string NationalId { get; set; }
        public DateTime BirthDate { get; set; }
        public List<CreateTagDto>? Tags { get; set; }
    }
}
