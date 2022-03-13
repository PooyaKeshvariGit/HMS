using HiringManagementSystem.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace HiringManagementSystem.Application.Interfaces
{
    [ScopedService]
    public interface ITagAppService
    {
        Task<List<TagDto>> GetAllAsync();
        Task<TagDto> GetByIdAsync(Guid id);
        Task CreateAsync(CreateTagDto tagDto);
        Task UpdateAsync(Guid id, TagDto tagDto);
        Task DeleteAsync(Guid id);
        //Special Task
        Task<TagDto> SearchByTagNameAsync(string tagName);
    }
}
