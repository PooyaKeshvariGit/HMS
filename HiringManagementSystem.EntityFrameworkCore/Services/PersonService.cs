using HiringManagementSystem.Domain.Aggregations.PersonAggregate;
using HiringManagementSystem.Domain.Repositories;
using HiringManagementSystem.EntityFrameworkCore.Frameworks.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiringManagementSystem.EntityFrameworkCore.Services
{
    public class PersonService : BaseService<Person, HiringManagementSystemDbContext, Guid>,
        IPersonRepository
    {
        #region [-Ctor-]

        public PersonService(HiringManagementSystemDbContext context)
            : base(context)
        {

        }

        #endregion

        #region [-SpecialTasks-]

        #region [-SearchByNationalIdAsync(string nationalId)-]

        public async Task<Person> SearchByNationalIdAsync(string nationalId)
        {
            var personNationalId = await DbSet.FirstOrDefaultAsync(x => x.NationalId == nationalId);
            return personNationalId;
        }

        #endregion

        #region [-SearchPersonByTagNameAsync(string tagName)-]

        public async Task<List<Person>> SearchPersonByTagNameAsync(string tagName)
        {
            var personTags = await DbSet.Where(x => x.Tags.Any(t => t.TagName.Contains(tagName))).ToListAsync();
            return personTags;
        }

        #endregion

        #region [-SearchTagByFamilyAsync(string family)-]

        public async Task<Person> SearchTagByFamilyAsync(string family)
        {
            var personFamily = await DbSet.FirstOrDefaultAsync(x => x.Family.Contains(family));
            return personFamily;
        }

        #endregion

        #endregion
    }
}
