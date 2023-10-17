using Microsoft.AspNetCore.Mvc;
using Schm.Domain.IService;
using System.Threading.Tasks;

namespace Schm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemUnitTypeController : Controller
    {
        public ItemUnitTypeController(IItemUnitTypeService itemUnitTypeService)
        {
            ItemUnitTypeService = itemUnitTypeService;
        }

        public IItemUnitTypeService ItemUnitTypeService { get; }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = ItemUnitTypeService.FindById(id);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetList()
        {
            var result = ItemUnitTypeService.GetAll();
            await Task.CompletedTask;
            return Ok(result);
        }
    }
}
