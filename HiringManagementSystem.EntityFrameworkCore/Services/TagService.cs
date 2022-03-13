using HiringManagementSystem.Domain.Aggregations.TagAggregate;
using HiringManagementSystem.Domain.Repositories;
using HiringManagementSystem.EntityFrameworkCore.Frameworks.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace HiringManagementSystem.EntityFrameworkCore.Services
{
    public class TagService : BaseService<Tag, HiringManagementSystemDbContext, Guid>,
        ITagRepository
    {
        #region [-Ctor-]

        public TagService(HiringManagementSystemDbContext context)
            : base(context)
        {

        }

        #endregion

        #region [-SpecialTasks-]

        #region [-SearchAsyncBy(string tagName)-]

        public async Task<Tag> SearchByTagNameAsync(string tagName)
        {
            var tag = await DbSet.FirstOrDefaultAsync(x => x.TagName == tagName);
            return tag;
        }

        #endregion


        #endregion
    }
}
