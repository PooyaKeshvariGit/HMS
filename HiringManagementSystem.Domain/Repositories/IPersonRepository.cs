using HiringManagementSystem.Domain.Aggregations.PersonAggregate;
using HiringManagementSystem.Domain.Contract.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace HiringManagementSystem.Domain.Repositories
{
    [ScopedService]
    public interface IPersonRepository : IRepository<Person, Guid>
    {
        Task<Person> SearchTagByFamilyAsync(string family);
        Task<Person> SearchByNationalIdAsync(string nationalId);
        Task<List<Person>> SearchPersonByTagNameAsync(string tagName);
    }
}
