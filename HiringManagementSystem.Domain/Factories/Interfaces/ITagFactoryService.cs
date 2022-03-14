using HiringManagementSystem.Domain.Aggregations.TagAggregate;
using System;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace HiringManagementSystem.Domain.Factories.Interfaces
{
    [ScopedService]
    public interface ITagFactoryService
    {
        Task<Tag> PrepareTagAsync(string tagName, string description, Guid personId);
    }
}