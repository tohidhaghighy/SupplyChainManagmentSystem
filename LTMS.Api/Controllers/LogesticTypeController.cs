using Microsoft.AspNetCore.Mvc;
using Schm.Domain.IService;
using System.Threading.Tasks;

namespace Schm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogesticTypeController : Controller
    {
        ILogesticTypeService _logesticTypeService;
        public LogesticTypeController(ILogesticTypeService logesticTypeService)
        {
            _logesticTypeService = logesticTypeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _logesticTypeService.FindById(id);
            await Task.CompletedTask;
            return Ok(result);
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetList()
        {
            var result = _logesticTypeService.GetAll();
            await Task.CompletedTask;
            return Ok(result);
        }

    }
}
