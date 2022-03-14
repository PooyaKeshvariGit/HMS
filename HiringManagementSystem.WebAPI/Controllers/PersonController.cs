using HiringManagementSystem.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HiringManagementSystem.Application.Interfaces;

namespace HiringManagementSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        #region [-Ctor-]

        public PersonController(IPersonAppService service)
        {
            Service = service;
        }

        #endregion

        #region [-Props-]

        public IPersonAppService Service { get; set; }

        #endregion

        #region [-API Methods-]

        #region [-GetAllPeopleAsync()-]
        [HttpGet("wapi/Person/GetAllPeople")]
        public async Task<List<PersonDto>> GetAllPeopleAsync()
        {
            var query = await Service.GetAllAsync();

            return query;
        }

        #endregion

        #region [-CreatePersonAsync(PersonDto Person)-]
        [HttpPost("wapi/Person/CreatePerson")]
        public async Task<IActionResult> CreatePersonAsync(CreatePersonDto dto)
        {
            await Service.CreateAsync(dto);
            return Ok();
        }

        #endregion

        #region [-UpdatePersonAsync(Guid id, PersonDto Person)-]
        [HttpPut("wapi/Person/Update")]
        public async Task UpdateAsync(Guid id, UpdatePersonDto dto)
        {
            await Service.UpdateAsync(id, dto);
        }

        #endregion

        #region [-DeletePersonAsync(Guid id)-]
        [HttpDelete("wapi/Person/DeletePerson")]
        public async Task DeletePersonAsync(Guid id)
        {
            await Service.DeleteAsync(id);
        }

        #endregion

        #region [-GetPersonByIdAsync(Guid id)-]
        [HttpGet("wapi/Person/GetPersonById")]
        public async Task<PersonDto> GetPersonByIdAsync(Guid id)
        {
            var person = await Service.GetByIdAsync(id);
            return person;
        }

        #endregion


        #region [-SearchTagByFamilyAsync(string family)-]
        [HttpGet("wapi/Person/SearchTagByFamily")]
        public async Task<IActionResult> SearchTagByFamilyAsync(string family)
        {
            var person = await Service.SearchTagByFamilyAsync(family);
            return Ok(person);
        }

        #endregion

        #region [-SearchByNationalIdAsync(string nationalId)-]
        [HttpGet("wapi/Person/SearchByNationalIdAsync")]
        public async Task<PersonDto> SearchByNationalIdAsync(string nationalId)
        {
            var person = await Service.SearchByNationalIdAsync(nationalId);
            return person;
        }

        #endregion

        #region [-SearchPersonBytagAsync(string tagName)-]
        [HttpGet("wapi/Person/SearchPersonBytagAsync")]
        public async Task<List<PersonDto>> SearchPersonByTagNameAsync(string tagName)
        {
            var person = await Service.SearchPersonByTagNameAsync(tagName);
            return person;
        }

        #endregion

        #endregion

    }
}
