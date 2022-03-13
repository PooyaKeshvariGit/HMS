using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringManagementSystem.Domain.Frameworks.Interfaces
{
    public interface IEntity<P_PrimaryKey>
    {
        P_PrimaryKey Id { get; set; }
    }
}
