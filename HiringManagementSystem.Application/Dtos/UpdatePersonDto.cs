using System;

namespace HiringManagementSystem.Application.Dtos
{
    public class UpdatePersonDto
    {
        public string FirstName { get; set; }
        public string Family { get; set; }
        public string NationalId { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
