using AutoMapper;
using HiringManagementSystem.Application.Dtos;
using HiringManagementSystem.Domain.Aggregations.PersonAggregate;
using HiringManagementSystem.Domain.Aggregations.TagAggregate;
using HiringManagementSystem.Domain.Factories.Interfaces;
using HiringManagementSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HiringManagementSystem.Application.Interfaces;

namespace HiringManagementSystem.Application.Services
{
    public class PersonAppService : IPersonAppService
    {
        #region [-Ctor-]

        public PersonAppService(IPersonFactoryService factory, IPersonRepository repository, IMapper mapper)
        {
            Factory = factory;
            Repository = repository;
            Mapper = mapper;
        }

        #endregion

        #region [-Props-]

        public IPersonFactoryService Factory { get; set; }
        public IPersonRepository Repository { get; set; }
        public IMapper Mapper { get; set; }

        #endregion

        #region [-Methods-]

        #region [-CreateAsync(PersonDto personDto)-]

        public async Task CreateAsync(CreatePersonDto personDto)
        {
            var person = Mapper.Map<Person>(personDto);

            await Repository.CreateAsync(person);
        }

        #endregion

        #region [-DeleteAsync(Guid id)-]

        public async Task DeleteAsync(Guid id)
        {
            await Repository.DeleteAsync(id);
        }

        #endregion

        #region [-GetAllAsync()-]

        public async Task<List<PersonDto>> GetAllAsync()
        {
            var query = await Repository.GetAllAsync();

            return Mapper.Map<List<PersonDto>>(query);
        }

        #endregion

        #region [-GetByIdAsync(Guid id)-]

        public async Task<PersonDto> GetByIdAsync(Guid id)
        {
            var person = await Repository.GetByIdAsync(id);
            return Mapper.Map<PersonDto>(person);
        }

        #endregion

        #region [-UpdateAsync(Guid id, PersonDto personDto)-]

        public async Task UpdateAsync(Guid id, UpdatePersonDto updatePersonDto)
        {
            var person = await Repository.GetByIdAsync(id);
            var mappedPerson = Mapper.Map(updatePersonDto, person);
            if (person != null)
            {
                await Repository.UpdateAsync(mappedPerson);
            }
        }

        #endregion


        #region [-SearchAsyncBy(string nationalId)-]

        public async Task<PersonDto> SearchByNationalIdAsync(string nationalId)
        {
            var person = await Repository.SearchByNationalIdAsync(nationalId);
            return Mapper.Map<PersonDto>(person);
        }

        #endregion

        #region [-SearchPersonByTagNameAsync(string tagName)-]

        public async Task<List<PersonDto>> SearchPersonByTagNameAsync(string tagName)
        {
            var person = await Repository.SearchPersonByTagNameAsync(tagName);
            return Mapper.Map<List<PersonDto>>(person);
        }

        #endregion

        #region [-SearchTagByFamilyAsync(string family)-]

        public async Task<PersonDto> SearchTagByFamilyAsync(string family)
        {
            var person = await Repository.SearchTagByFamilyAsync(family);
            return Mapper.Map<PersonDto>(person);
        }

        #endregion

        #endregion
    }
}
