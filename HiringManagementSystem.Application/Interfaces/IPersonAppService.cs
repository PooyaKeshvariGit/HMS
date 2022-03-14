using HiringManagementSystem.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace HiringManagementSystem.Application.Interfaces
{
    [ScopedService]
    public interface IPersonAppService
    {
        Task<List<PersonDto>> GetAllAsync();
        Task<PersonDto> GetByIdAsync(Guid id);
        Task CreateAsync(CreatePersonDto personDto);
        Task UpdateAsync(Guid id, UpdatePersonDto updatePersonDto);
        Task DeleteAsync(Guid id);
        //Special Tasks
        Task<PersonDto> SearchTagByFamilyAsync(string family);
        Task<PersonDto> SearchByNationalIdAsync(string nationalId);
        Task<List<PersonDto>> SearchPersonByTagNameAsync(string tagName);
    }
}
