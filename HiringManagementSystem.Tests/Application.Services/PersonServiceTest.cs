using AutoFixture;
using AutoFixture.Xunit2;

using AutoMapper;

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
            //var mockMapper = AutoFixture.Freeze<Mock<IMapper>>();

            //mockMapper.Setup(m => m.Map<List<PersonDto>>(It.IsAny<List<Person>>()))
            //    .Returns<List<Person>>(persons =>
            //    {
            //        return persons.Select(person => new PersonDto
            //        {
            //            Id = person.Id,
            //            FirstName = person.FirstName,
            //            Family = person.Family,
            //            BirthDate = person.BirthDate,
            //            NationalId = person.NationalId
            //        }).ToList();
            //    });

        } 

        #endregion

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

        #region [-Should_Update_Person(CreatePersonDto dto)-]

        public async Task Should_Update_Person(CreatePersonDto dto)
        {

        }

        #endregion

        #region [--]



        #endregion
    }
}
