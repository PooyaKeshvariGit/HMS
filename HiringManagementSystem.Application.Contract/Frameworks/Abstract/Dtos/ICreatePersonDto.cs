using System;

namespace HiringManagementSystem.Application.Contract.Frameworks.Abstract.Dtos
{
    public interface ICreatePersonDto
    {
        string FirstName { get; set; }
        string Family { get; set; }
        string NationalId { get; set; }
        DateTime BirthDate { get; set; }
    }
}
