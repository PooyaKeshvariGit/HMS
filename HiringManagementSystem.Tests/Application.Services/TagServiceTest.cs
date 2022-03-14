using AutoFixture;
using AutoFixture.Xunit2;
using HiringManagementSystem.Application.Dtos;
using HiringManagementSystem.Application.Services;
using HiringManagementSystem.Domain.Aggregations.TagAggregate;
using HiringManagementSystem.Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HiringManagementSystem.Tests.Application.Services
{
    public class TagServiceTest : TestFixture
    {
        #region [-Props-]

        public Mock<ITagRepository> MockRepository { get; set; }
        public IEnumerable<Tag> Tags { get; set; }

        #endregion

        #region [-Ctor-]

        public TagServiceTest()
        {
            Tags = AutoFixture.CreateMany<Tag>(10);
            MockRepository = AutoFixture.Freeze<Mock<ITagRepository>>();
        }

        #endregion

        #region [-Tests-]

        #region [-Should_Get_All_Tags()-]

        [Fact]
        public async Task Should_Get_All_Tags()
        {
            //Arrange
            MockRepository.Setup(m => m.GetAllAsync())
                .Returns(Task.FromResult(Tags.ToList()));

            var sut = AutoFixture.Create<TagAppService>();

            //Act
            var result = await sut.GetAllAsync();

            //Assert
            foreach (var dto in result)
            {
                var tag = Tags.FirstOrDefault(t => t.Id == dto.Id);
                Assert.Equal(tag.TagName, dto.TagName);
                Assert.Equal(tag.Description, dto.Description);
                Assert.Equal(tag.PersonId, dto.PersonId);
            }
        }

        #endregion

        #region [-Should_Create_Tag(CreateTagDto tagDto)-]

        [Theory]
        [AutoData]
        public async Task Should_Create_Tag(CreateTagDto tagDto)
        {
            //Arrange
            Tag actualCreateTag = null;

            MockRepository.Setup(m => m.CreateAsync(It.IsAny<Tag>()))
                .Callback<Tag>(tag => actualCreateTag = tag);

            var sut = AutoFixture.Create<TagAppService>();

            //Act
            await sut.CreateAsync(tagDto);

            //Assert
            Assert.NotNull(actualCreateTag);

            Assert.Equal(actualCreateTag.TagName, tagDto.TagName);
            Assert.Equal(actualCreateTag.Description, tagDto.Description);
            Assert.Equal(actualCreateTag.PersonId, tagDto.PersonId);
        }

        #endregion

        #region [-Should_Update_Tag(Guid id, TagDto tagDto)-]

        [Theory]
        [AutoData]
        public async Task Should_Update_Tag(Guid id, TagDto tagDto)
        {
            //Arrange
            Tag actualUpdateTag = null;
            MockRepository.Setup(m => m.GetByIdAsync(id))
                .Returns(Task.FromResult(Tags.First()));

            MockRepository.Setup(m => m.UpdateAsync(It.IsAny<Tag>()))
                .Callback<Tag>(tag => actualUpdateTag = tag);

            var sut = AutoFixture.Create<TagAppService>();

            //Act
            await sut.UpdateAsync(id, tagDto);

            //Assert
            Assert.Equal(actualUpdateTag.TagName, tagDto.TagName);
            Assert.Equal(actualUpdateTag.Description, tagDto.Description);
            Assert.Equal(actualUpdateTag.PersonId, tagDto.PersonId);

        }

        #endregion

        #region [-Should_Delete_Tag(Guid id)-]

        [Theory]
        [AutoData]
        public async Task Should_Delete_Tag(Guid id)
        {
            //Arrange
            Guid actualId = new Guid();
            MockRepository.Setup(m => m.DeleteAsync(It.IsAny<Guid>()))
                .Callback<Guid>(tag => actualId = id);

            var sut = AutoFixture.Create<TagAppService>();
            //Act
            await sut.DeleteAsync(id);

            //Assert
            Assert.Equal(actualId,id);

        }

        #endregion

        #region [-Should_Get_Person_By_TagName(string tagName)-]

        [Theory]
        [AutoData]
        [InlineAutoData(false)]
        [InlineAutoData(true)]
        public async Task Should_Get_Tag_By_TagName(bool exptectedFound , string tagName)
        {
            //Arrange
            MockRepository.Setup(m => m.SearchByTagNameAsync(It.IsAny<string>()))
                .Returns<string>(f => Task.FromResult(Tags.FirstOrDefault(p => p.TagName.Contains(f))));

            if (exptectedFound)
            {
                Tags.Last().TagName = "lafskdjlkfsadj ljl lsadfj" + tagName + "lafsdkjlkdsjlfdkjalj";
            }

            var sut = AutoFixture.Create<TagAppService>();

            //Act
            var result = await sut.SearchByTagNameAsync(tagName);

            //Assert
            if (exptectedFound)
            {
                var expectedTag = Tags.FirstOrDefault(p => p.TagName.Contains(tagName));

                Assert.NotNull(result);
                Assert.Equal(expectedTag.TagName, result.TagName);
                Assert.Equal(expectedTag.Description, result.Description);
                Assert.Equal(expectedTag.PersonId, result.PersonId);
                Assert.Equal(expectedTag.Id, result.Id);
            }
            else
            {
                Assert.Null(result);
            }


        }

        #endregion

        #endregion

    }
}
