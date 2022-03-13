using HiringManagementSystem.Domain.Aggregations.TagAggregate;
using HiringManagementSystem.Domain.Repositories;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringManagementSystem.Tests.Application.Services
{
    public class TagServiceTest:TestFixture
    {
        #region [-Props-]

        public Mock<ITagRepository> MockRepository { get; set; }
        public IEnumerable<Tag> Tags { get; set; }

        #endregion

        #region [-Ctor-]

        public TagServiceTest()
        {


        }

        #endregion

        #region [--]



        #endregion

    }
}
