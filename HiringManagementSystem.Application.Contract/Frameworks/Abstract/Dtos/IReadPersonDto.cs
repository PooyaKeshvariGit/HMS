using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringManagementSystem.Application.Contract.Frameworks.Abstract.Dtos
{
    public interface IReadPersonDto
    {
        string FirstName { get; set; }
        string Family { get; set; }
        string NationalId { get; set; }
        DateTime BirthDate { get; set; }
    }
}
