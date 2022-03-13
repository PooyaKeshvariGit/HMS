using HiringManagementSystem.Domain.Aggregations.PersonAggregate;
using HiringManagementSystem.Domain.Aggregations.TagAggregate;
using HiringManagementSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace HiringManagementSystem.Domain.Factories.Interfaces
{
    [ScopedService]
    public interface IPersonFactoryService
    {
        IPersonRepository PersonRepository { get; set; }
        ITagRepository TagRepository { get; set; }

        Task<Person> PrepareForCreatePersonAsync(string firstName, string family, string nationalId, DateTime birthDate, List<Tag> tags);
        Task<Person> PreparePersonAsync(string firstName, string family, string nationalId, DateTime birthDate, List<Tag> tags);
    }
}