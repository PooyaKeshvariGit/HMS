using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace HiringManagementSystem.Tests
{
    public class PersonTests
    {
        ////Using Moq for Simplicity
        //private readonly PersonService _personService;
        //private readonly Mock<IPersonRepository> _personRepositoryMock = new Mock<IPersonRepository>();
        //public string PersonName { get; set; }
        
        //public string PersonNameMethod(string name)
        //{
        //    return PersonName = name;
        //}
        //public PersonTests()
        //{
        //    _personService = new PersonService(_personService.Object);
        //}

        //[Fact]
        //public async Task<Person> GetPersonById_ShouldReturnPerson_WhenPersonExists()
        //{
        //    //Arrange  - All Needs To Use And I Expect To See in This Test .
        //    var personId = Guid.NewGuid();//1
        //    var personFirstName = "MrP";//4
        //    var personLastName = "MrK";//4
        //    var personDto = new PersonDto //4
        //    {
        //        Id = personId,
        //        FirstName = personFirstName,
        //        LastName = personLastName
        //    };
        //    _personRepositoryMock.Setup(x => x.GetPersonByIdAsync(personId)).Returns(personDto);//5
        //    //Act
        //    var person = await _personService.GetPersonByIdAsync(personId);//2

        //    //Assert
        //    Assert.NotNull(person);//3
        //    Assert.Equal(person.Id, personId);//3    But Moq is Not Installed yet
        //    Assert.Equal(personFirstName, person.FirstName);
        //}

        //[Fact]
        //public async Task<Person> GetPersonByName_ShouldReturnPerson_WhenPersonExists()
        //{
        //    //Arrange 
        //    string name = "mrP";
        //    var personName = PersonNameMethod(name);
        //    var mockContext = new Mock<HiringManagementSystemContext>();
        //    var mockSet = new Mock<DbSet<Person>>();

        //    //Act
        //    mockSet.Setup(x => x.GetPersonByNameAsync(personName)).Returns(mockSet);

        //    //Assert    
        //    Assert.NotNull(person);
        //    Assert.Equal(person.FirstName, personName);
        //}





    }
}
