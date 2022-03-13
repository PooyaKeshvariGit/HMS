using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringManagementSystem.Application.Contract.Frameworks.Abstract.Dtos
{
    public interface ICreateTagDto
    {
        string TagName { get; set; }
        string Description { get; set; }
    }
}
