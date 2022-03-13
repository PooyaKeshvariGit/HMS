using HiringManagementSystem.Application.Dtos;
using HiringManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiringManagementSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        #region [-Ctor-]

        public TagController(ITagAppService service)
        {
            Service = service;
        }

        #endregion

        #region [-Prop-]

        public ITagAppService Service { get; set; }

        #endregion

        #region [-API Methods-]

        #region [-GetAllTagsAsync()-]
        [HttpGet("wapi/Tag/GetAllTagsAsync")]
        public async Task<List<TagDto>> GetAllTagsAsync()
        {
            var query = await Service.GetAllAsync();
            return query;
        }

        #endregion

        #region [-CreateTagAsync(TagDto tag)-]
        [HttpPost("wapi/Tag/CreateTagAsync")]
        public async Task CreateTagAsync(CreateTagDto tag)
        {
            await Service.CreateAsync(tag);
        }

        #endregion

        #region [-UpdateTagAsync(Guid id, TagDto tag)-]
        [HttpPut("wapi/Tag/UpdateTagAsync")]
        public async Task UpdateTagAsync(Guid id, TagDto tag)
        {
            await Service.UpdateAsync(id, tag);
        }

        #endregion

        #region [-DeleteTagAsync(Guid id)-]
        [HttpDelete("wapi/Tag/DeleteTagAsync")]
        public async Task DeleteTagAsync(Guid id)
        {
            await Service.DeleteAsync(id);
        }

        #endregion

        #region [-GetTagByIdAsync(Guid id)-]
        [HttpGet("wapi/Tag/GetTagByIdAsync")]
        public async Task<IActionResult> GetTagByIdAsync(Guid id)
        {
            var tag = await Service.GetByIdAsync(id);
            return Ok(tag);
        }

        #endregion

        #region [-SearchByTagNameAsync(string tagName)-]
        [HttpGet("wapi/Tag/SearchByTagNameAsync")]
        public async Task<TagDto> SearchByTagNameAsync(string tagName)
        {
            var tag = await Service.SearchByTagNameAsync(tagName);
            return tag;
        }

        #endregion

        #endregion
    }
}
