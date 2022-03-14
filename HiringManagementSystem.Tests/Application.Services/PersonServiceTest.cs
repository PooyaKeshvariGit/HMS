using AutoFixture;
using AutoFixture.Xunit2;

using HiringManagementSystem.Application.Dtos;
using HiringManagementSystem.Application.Services;
using HiringManagementSystem.Domain.Aggregations.PersonAggregate;
using HiringManagementSystem.Domain.Repositories;

using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;

namespace HiringManagementSystem.Tests.Application.Services
{
    public class PersonServiceTest : TestFixture
    {
        #region [-Props-]
        public IEnumerable<Person> People { get; set; }
        public Mock<IPersonRepository> MockRepository { get; set; }
        #endregion

        #region [-Ctor-]

        public PersonServiceTest()
        {
            People = AutoFixture.CreateMany<Person>(10);

            MockRepository = AutoFixture.Freeze<Mock<IPersonRepository>>();
        }

        #endregion

        #region [-Tests-]

        #region [-Should_Get_All_Persons()-]

        [Fact]
        public async Task Should_Get_All_Persons()
        {
            //Arrange
            MockRepository.Setup(m => m.GetAllAsync())
                .Returns(() => Task.FromResult(People.ToList()));

            var sut = AutoFixture.Create<PersonAppService>();

            //Act
            var result = await sut.GetAllAsync();

            foreach (var dto in result)
            {
                var person = People.FirstOrDefault(p => p.Id == dto.Id);

                Assert.NotNull(person);

                Assert.Equal(dto.FirstName, person.FirstName);
                Assert.Equal(dto.Family, person.Family);
                Assert.Equal(dto.BirthDate, person.BirthDate);
                Assert.Equal(dto.NationalId, person.NationalId);
            }
        }

        #endregion

        #region [-Should_Create_Person_With_Tags(PersonDto dto)-]

        [Theory]
        [AutoData]
        public async Task Should_Create_Person_With_Tags(CreatePersonDto dto)
        {
            //Arrange
            Person actualCreatedPerson = null;

            MockRepository.Setup(m => m.CreateAsync(It.IsAny<Person>()))
                .Callback<Person>(person => actualCreatedPerson = person);

            var sut = AutoFixture.Create<PersonAppService>();

            //Act
            await sut.CreateAsync(dto);

            //Assert
            Assert.NotNull(actualCreatedPerson);

            Assert.Equal(dto.FirstName, actualCreatedPerson.FirstName);
            Assert.Equal(dto.Family, actualCreatedPerson.Family);
            Assert.Equal(dto.BirthDate, actualCreatedPerson.BirthDate);
            Assert.Equal(dto.NationalId, actualCreatedPerson.NationalId);

            Assert.NotNull(actualCreatedPerson.Tags);
            Assert.NotEmpty(actualCreatedPerson.Tags);
            foreach (var tag in actualCreatedPerson.Tags)
            {
                Assert.Contains(dto.Tags, expectedTag => expectedTag.TagName == tag.TagName && expectedTag.Description == tag.Description);
            }
        }

        #endregion

        #region [-Should_Create_Person_Without_Tags(CreatePersonDto dto)-]

        [Theory]
        [AutoData]
        public async Task Should_Create_Person_Without_Tags(CreatePersonDto dto)
        {
            //Arrange
            Person actualCreatedPerson = null;
            dto.Tags = null;
            MockRepository.Setup(m => m.CreateAsync(It.IsAny<Person>()))
                .Callback<Person>(person => actualCreatedPerson = person);

            var sut = AutoFixture.Create<PersonAppService>();

            //Act
            await sut.CreateAsync(dto);

            //Assert
            Assert.NotNull(actualCreatedPerson);
            Assert.Equal(dto.FirstName, actualCreatedPerson.FirstName);
            Assert.Equal(dto.Family, actualCreatedPerson.Family);
            Assert.Equal(dto.BirthDate, actualCreatedPerson.BirthDate);
            Assert.Equal(dto.NationalId, actualCreatedPerson.NationalId);
            Assert.Empty(actualCreatedPerson.Tags);
        }

        #endregion

        #region [-Should_Update_Person(UpdatePersonDto dto)-]

        [Theory]
        [AutoData]
        public async Task Should_Update_Person(Guid id, UpdatePersonDto dto)
        {
            //Arrange

            Person actualUpdatePerson = null;
            MockRepository.Setup(m => m.GetByIdAsync(id))
            .Returns(Task.FromResult(People.First()));

            MockRepository.Setup(m => m.UpdateAsync(It.IsAny<Person>()))
                .Callback<Person>(person => actualUpdatePerson = person);

            var sut = AutoFixture.Create<PersonAppService>();

            //Act
            await sut.UpdateAsync(id, dto);

            //Assert
            Assert.Equal(dto.FirstName, actualUpdatePerson.FirstName);
            Assert.Equal(dto.Family, actualUpdatePerson.Family);
            Assert.Equal(dto.BirthDate, actualUpdatePerson.BirthDate);
            Assert.Equal(dto.NationalId, actualUpdatePerson.NationalId);

        }

        #endregion

        #region [-Should_Delete_Person(Guid id)-] 

        [Theory]
        [AutoData]
        public async Task Should_Delete_Person(Guid id)
        {
            //Arrange
            Guid actualId = new Guid();
            MockRepository.Setup(m => m.DeleteAsync(It.IsAny<Guid>()))
                .Callback<Guid>(id => actualId = id);

            var sut = AutoFixture.Create<PersonAppService>();
            //Act
            await sut.DeleteAsync(id);

            //Assert
            Assert.Equal(id, actualId);

        }

        #endregion

        #region [-Should_Get_Person_By_Family(bool exptectedFound,string family)-]

        [Theory]
        [InlineAutoData(false)]
        [InlineAutoData(true)]
        public async Task Should_Get_Person_By_Family(bool exptectedFound, string family)
        {
            //Arrange
            MockRepository.Setup(m => m.SearchTagByFamilyAsync(It.IsAny<string>()))
                .Returns<string>(f => Task.FromResult(People.FirstOrDefault(p => p.Family.Contains(f))));
            if (exptectedFound)
            {
                People.Last().Family = "lafskdjlkfsadj ljl lsadfj" + family + "lafsdkjlkdsjlfdkjalj";
            }

            var sut = AutoFixture.Create<PersonAppService>();

            //Act
            var result = await sut.SearchTagByFamilyAsync(family);

            //Assert
            if (exptectedFound)
            {
                var expectedPerson = People.FirstOrDefault(p => p.Family.Contains(family));

                Assert.NotNull(result);

                Assert.Equal(expectedPerson.Family, result.Family);
                Assert.Equal(expectedPerson.FirstName, result.FirstName);
                Assert.Equal(expectedPerson.BirthDate, result.BirthDate);
                Assert.Equal(expectedPerson.NationalId, result.NationalId);
                Assert.Equal(expectedPerson.Id, result.Id);
            }
            else
            {
                Assert.Null(result);
            }

        }

        #endregion

        #region [-Should_Get_Person_By_NationalId(bool exptectedFound,string nationalId)-]

        [Theory]
        [AutoData]
        [InlineAutoData(false)]
        [InlineAutoData(true)]
        public async Task Should_Get_Person_By_NationalId(bool exptectedFound, string nationalId)
        {
            //Arrange
            MockRepository.Setup(m => m.SearchByNationalIdAsync(It.IsAny<string>()))
                .Returns<string>(f => Task.FromResult(People.FirstOrDefault(p => p.NationalId.Contains(f))));
            if (exptectedFound)
            {
                People.Last().NationalId = "lafskdjlkfsadj ljl lsadfj" + nationalId + "lafsdkjlkdsjlfdkjalj";
            }

            var sut = AutoFixture.Create<PersonAppService>();

            //Act
            var result = await sut.SearchByNationalIdAsync(nationalId);

            //Assert
            if (exptectedFound)
            {
                var expectedPerson = People.FirstOrDefault(p => p.NationalId.Contains(nationalId));

                Assert.NotNull(result);

                Assert.Equal(expectedPerson.Family, result.Family);
                Assert.Equal(expectedPerson.FirstName, result.FirstName);
                Assert.Equal(expectedPerson.BirthDate, result.BirthDate);
                Assert.Equal(expectedPerson.NationalId, result.NationalId);
                Assert.Equal(expectedPerson.Id, result.Id);
            }
            else
            {
                Assert.Null(result);
            }

        }

        #endregion

        #region [-Should_Get_Person_By_TagName(bool exptectedFound,string tagName)-]

        [Theory]
        [InlineAutoData(0)]
        [InlineAutoData(4)]
        public async Task Should_Get_Person_By_TagName(int exptectedFoundCount, string tagName)
        {
            //Arrange
            MockRepository.Setup(m => m.SearchPersonByTagNameAsync(It.IsAny<string>()))
                .Returns<string>(f => Task.FromResult(People.Where(x => x.Tags.Any(t => t.TagName.Contains(tagName))).ToList()));
            if (exptectedFoundCount > 0)
            {
                for (int i = 0; i < exptectedFoundCount; i++)
                {
                    People.ToList()[i].Tags.Last().TagName = "lafskdjlkfsadj ljl lsadfj" + tagName + "lafsdkjlkdsjlfdkjalj";
                }
            }

            var sut = AutoFixture.Create<PersonAppService>();

            //Act
            var result = await sut.SearchPersonByTagNameAsync(tagName);

            //Assert
            if (exptectedFoundCount > 0)
            {
                Assert.Equal(exptectedFoundCount, result.Count);

                foreach (var expectedPerson in People.Where(p => p.Tags.Any(t => t.TagName.Contains(tagName))))
                {
                    var actualPerson = result.FirstOrDefault(p => p.Id == expectedPerson.Id);

                    Assert.NotNull(actualPerson);

                    Assert.Equal(expectedPerson.Family, actualPerson.Family);
                    Assert.Equal(expectedPerson.FirstName, actualPerson.FirstName);
                    Assert.Equal(expectedPerson.BirthDate, actualPerson.BirthDate);
                    Assert.Equal(expectedPerson.NationalId, actualPerson.NationalId);
                }
            }
            else
            {
                Assert.Empty(result);
            }


        }

        #endregion

        #endregion
    }
}
