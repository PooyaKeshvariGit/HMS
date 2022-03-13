using HiringManagementSystem.Domain.Aggregations.TagAggregate;
using HiringManagementSystem.Domain.Contract.Interface;
using System;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace HiringManagementSystem.Domain.Repositories
{
    [ScopedService]
    public interface ITagRepository : IRepository<Tag, Guid>
    {
        Task<Tag> SearchByTagNameAsync(string tagName);
    }
}
