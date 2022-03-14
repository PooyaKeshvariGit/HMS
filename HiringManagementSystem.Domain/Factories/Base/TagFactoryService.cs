using HiringManagementSystem.Domain.Aggregations.TagAggregate;
using HiringManagementSystem.Domain.Factories.Interfaces;
using HiringManagementSystem.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace HiringManagementSystem.Domain.Factories.Base
{
    public class TagFactoryService : ITagFactoryService
    {
        #region [-Ctor-]

        public TagFactoryService(ITagRepository tagRepository)
        {
            TagRepository = tagRepository;
        }

        #endregion

        #region [-Props-]

        public ITagRepository TagRepository { get; set; }

        #endregion

        #region [-Methods-]

        #region [-PrepareTagAsync(string tagName)-]

        public async Task<Tag> PrepareTagAsync(string tagName, string description, Guid personId)
        {
            var exist = await TagRepository.SearchByTagNameAsync(tagName);
            if (exist == null)
            {
                return new Tag()
                {
                    Id = Guid.NewGuid(),
                    TagName = tagName,
                    Description = description,
                    PersonId = personId
                };
            }
            else
            {
                return null;
            }
        }

        #endregion

        #endregion
    }
}
