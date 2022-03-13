using System;

namespace HiringManagementSystem.Application.Dtos
{
    public class PersonDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Family { get; set; }
        public string NationalId { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
