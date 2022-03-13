using AutoFixture;
using AutoMapper;
using HiringManagementSystem.Application.Dtos;
using HiringManagementSystem.Application.Services;
using HiringManagementSystem.Domain.Aggregations.PersonAggregate;
using HiringManagementSystem.Domain.Repositories;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HiringManagementSystem.Tests.Application.Services
{
    public class PersonServiceTest : TestFixture
    {
        public IEnumerable<Person> People { get; set; }

        public PersonServiceTest()
        {
            People = AutoFixture.CreateMany<Person>(10);
            

            var mockRepository = AutoFixture.Freeze<Mock<IPersonRepository>>();
            var mockMapper = AutoFixture.Freeze<Mock<IMapper>>();

            mockRepository.Setup(m => m.GetAllAsync())
                .Returns(() => Task.FromResult(People.ToList()));

            mockMapper.Setup(m => m.Map<List<PersonDto>>(It.IsAny<List<Person>>()))
                .Returns<List<Person>>(persons =>
                {
                    return persons.Select(person => new PersonDto
                    {
                        FirstName = person.FirstName,
                        Family = person.Family,
                        BirthDate = person.BirthDate,
                        NationalId = person.NationalId
                    }).ToList();
                });

        }

        [Fact]
        public async Task Should_Get_All_Persons()
        {
            var sut = AutoFixture.Create<PersonAppService>();
            var result = await sut.GetAllAsync();

            Assert.Equal(People.ToList().Count, result.Count);

            foreach (var person in People)
            {
                var personDto = new PersonDto
                {
                    FirstName = person.FirstName,
                    Family = person.Family,
                    BirthDate = person.BirthDate,
                    NationalId = person.NationalId
                };

                Assert.Contains(result, dto => dto.Family == person.Family && dto.FirstName == person.FirstName && dto.BirthDate == person.BirthDate && dto.NationalId == person.NationalId);
            }
        }

        [Theory]
        public async Task Should_Create_Person()
        {
            var sut = AutoFixture.Create<PersonAppService>();
            var result = await sut.GetAllAsync();

            Assert.Equal(People.ToList().Count, result.Count);

            foreach (var person in People)
            {
                var personDto = new PersonDto
                {
                    FirstName = person.FirstName,
                    Family = person.Family,
                    BirthDate = person.BirthDate,
                    NationalId = person.NationalId
                };

                Assert.Contains(result, dto => dto.Family == person.Family && dto.FirstName == person.FirstName && dto.BirthDate == person.BirthDate && dto.NationalId == person.NationalId);
            }
        }


    }
}
