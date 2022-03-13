using HiringManagementSystem.Application.Contract.Frameworks.Abstract.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HiringManagementSystem.Application.Contract.Frameworks.Base.Dtos
{
    public class BasePersonDto
    {
        public string FirstName { get; set; }
        public string Family { get; set; }
        public string NationalId { get; set; }
        public DateTime BirthDate { get; set; }
        [JsonProperty("tags")]
        public List<BaseTagDto> Tags { get; set; }
    }
}
