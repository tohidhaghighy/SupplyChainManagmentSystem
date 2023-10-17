using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Schm.UI.Infrastructure.Config;

namespace Schm.UI.Controllers
{
    public class ErrorController : Controller
    {
        public IOptions<Config> Options { get; }

        public ErrorController(IOptions<Config> options)
        {
            Options = options;
        }
        public IActionResult Error404()
        {
            ViewData["Login"] = Options.Value.LoginUrl;
            return View();
        }

        public IActionResult Error401()
        {
            ViewData["Login"] = Options.Value.LoginUrl;
            return View();
        }
    }
}
