using HiringManagementSystem.Domain.Aggregations.PersonAggregate;
using HiringManagementSystem.Domain.Aggregations.TagAggregate;
using HiringManagementSystem.Domain.Factories.Interfaces;
using HiringManagementSystem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiringManagementSystem.Domain.Factories.Base
{
    public class PersonFactoryService : IPersonFactoryService
    {
        #region [-Ctor-]

        public PersonFactoryService(IPersonRepository personRepository)
        {
            PersonRepository = personRepository;
        }

        #endregion

        #region [-Props-]

        public IPersonRepository PersonRepository { get; set; }
        public ITagRepository TagRepository { get; set; }

        #endregion

        #region [-Methods-]

        #region [-PreparePersonAsync(  )-]

        public async Task<Person> PreparePersonAsync
            (string firstName, string family, string nationalId, DateTime birthDate, List<Tag> tags)
        {
            var exist = await PersonRepository.SearchByNationalIdAsync(nationalId);
            if (exist == null)
            {
                return new Person()
                {
                    Id = Guid.NewGuid(),
                    FirstName = firstName,
                    Family = family,
                    NationalId = nationalId,
                    BirthDate = birthDate,
                    Tags = tags
                };
            }
            else
            {
                return null;
            }
        }

        #endregion

        public async Task<Person> PrepareForCreatePersonAsync
            (string firstName, string family, string nationalId, DateTime birthDate, List<Tag> tags)
        {
            //var domainTagName = tags.Select(q => q.TagName).FirstOrDefault();
            //var tagCollection = new List<Tag>();
            //foreach (var item in tags)
            //{
            //    domainTagName= item.TagName;
            //    tagCollection.Add(item);
            //}
            var exist = await PersonRepository.SearchByNationalIdAsync(nationalId);
            if (exist == null)
            {
                return new Person()
                {
                    Id = Guid.NewGuid(),
                    FirstName = firstName,
                    Family = family,
                    NationalId = nationalId,
                    BirthDate = birthDate,
                    Tags = tags
                };
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
