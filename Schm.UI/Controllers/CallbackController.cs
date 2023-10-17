using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Schm.UI.Infrastructure.Common;
using Schm.UI.Infrastructure.Config;

namespace Schm.UI.Controllers
{
    [Route("/Api/{controller}")]
    public class CallbackController : Controller
    {
        public IOptions<Config> ApiOptions { get; }
        public IOptions<JwtInfo> Options { get; }
        public CallbackController(IOptions<JwtInfo> options, IOptions<Config> apiOptions)
        {
            Options = options;
            ApiOptions = apiOptions;
        }
        [Route("SSO")]
        public async Task<IActionResult> Index(string accessToken)
        {
            if (JwtToken.ValidateCurrentToken(accessToken,Options.Value.Issuer,Options.Value.Audience,Options.Value.Key))
            {
                HttpContext.Session.SetInt32("UserId", Convert.ToInt32(JwtToken.GetClaim(accessToken,"UserId")));
                HttpContext.Session.SetString("Username", JwtToken.GetClaim(accessToken, "Username"));
                HttpContext.Session.SetInt32("UserRole", Convert.ToInt32(JwtToken.GetClaim(accessToken, "UserRole")));
                HttpContext.Session.SetInt32("SupplierId", ApiOptions.Value.SupplierId );
                return Redirect("/Home/Index");
            }
            return Redirect("/Error/Error404");
        }
    }
}
