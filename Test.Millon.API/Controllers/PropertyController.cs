using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Test.Millon.API.Models.Dtos;
using Test.Millon.API.Services;

namespace Test.Millon.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]/[Action]")]
    public class PropertyController : ControllerBase
    {
        private readonly InterfaceAdapter _interfaceAdapter;

        public PropertyController(InterfaceAdapter interfaceAdapter)
        {
            _interfaceAdapter = interfaceAdapter;
        }

        [HttpPost(Name = "CreatePropertyBuilding")]
        public async Task<IActionResult> CreatePropertyBuilding([FromBody] PropertyBuildingDTO model) 
            => Ok(await _interfaceAdapter.CreatePropertyBuilding(model));

        [HttpPost(Name = "AddImageFromProperty")]
        public async Task<IActionResult> AddImageFromProperty([FromBody] PropertyImageDTO model)
            => Ok(await _interfaceAdapter.AddImageFromProperty(model));

        [HttpPut(Name = "ChangePrice")]
        public async Task<IActionResult> ChangePrice([FromBody] ChangePriceDTO model) 
            => Ok(await _interfaceAdapter.ChangePrice(model));

        [HttpPut(Name = "{id}")]
        public async Task<IActionResult> UpdateProperty(Guid id, [FromBody] PropertyBuildingDTO model) 
            => Ok(await _interfaceAdapter.UpdateProperty(id,model));


        [HttpGet(Name = "ListPropertyWithFilters")]
        public async Task<IActionResult> ListPropertyWithFilters(string? filters) 
            => Ok(await _interfaceAdapter.ListPropertyWithFilters(filters));
    }
}
