using HiringManagementSystem.Domain.Aggregations.TagAggregate;
using HiringManagementSystem.Domain.Repositories;
using System;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace HiringManagementSystem.Domain.Factories.Interfaces
{
    [ScopedService]
    public interface ITagFactoryService
    {
        ITagRepository TagRepository { get; set; }

        Task<Tag> PrepareTagAsync(string tagName, string description, Guid personId);
    }
}