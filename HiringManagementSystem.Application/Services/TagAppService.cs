using AutoMapper;
using HiringManagementSystem.Application.Dtos;
using HiringManagementSystem.Domain.Factories.Interfaces;
using HiringManagementSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HiringManagementSystem.Application.Interfaces;
using HiringManagementSystem.Domain.Aggregations.TagAggregate;

namespace HiringManagementSystem.Application.Services
{
    public class TagAppService : ITagAppService
    {
        #region [-Ctor-]

        public TagAppService(ITagFactoryService factory, ITagRepository repository, IMapper mapper)
        {
            Factory = factory;
            Repository = repository;
            Mapper = mapper;
        }

        #endregion

        #region [-Props-]

        public ITagFactoryService Factory { get; set; }
        public ITagRepository Repository { get; set; }
        public IMapper Mapper { get; set; }

        #endregion

        #region [-Methods-]

        #region [-CreateAsync(TagDto tagDto)-]

        public async Task CreateAsync(CreateTagDto tagDto)
        {
            var preparedTag = Mapper.Map<Tag>(tagDto);
            await Repository.CreateAsync(preparedTag);
            
        }

        #endregion

        #region [-DeleteAsync(Guid id)-]

        public async Task DeleteAsync(Guid id)
        {
            await Repository.DeleteAsync(id);
        }

        #endregion

        #region [-GetAllAsync()-]

        public async Task<List<TagDto>> GetAllAsync()
        {
            var query = await Repository.GetAllAsync();
            return Mapper.Map<List<TagDto>>(query);
        }

        #endregion

        #region [-GetByIdAsync(Guid id)-]

        public async Task<TagDto> GetByIdAsync(Guid id)
        {
            var tag = await Repository.GetByIdAsync(id);
            return Mapper.Map<TagDto>(tag);
        }

        #endregion

        #region [-UpdateAsync(Guid id,TagDto tagDto)-]

        public async Task UpdateAsync(Guid id,TagDto tagDto)
        {
            var tag = await Repository.GetByIdAsync(id);
            if (tag != null)
            {
                tag.TagName = tagDto.TagName ;
                tag.Description = tagDto.Description;
                tag.PersonId = tagDto.PersonId;
                await Repository.UpdateAsync(tag);
            }
        }

        #endregion

        #region [-SearchByTagNameAsync(string tagName)-]

        public async Task<TagDto> SearchByTagNameAsync(string tagName)
        {
            var tag=await Repository.SearchByTagNameAsync(tagName);
            return Mapper.Map<TagDto>(tag);
        }

        #endregion

        #endregion
    }
}
