namespace Schm.UI.Infrastructure.Middleware
{
    public class CheckSession
    {
        private readonly RequestDelegate _next;

        public CheckSession(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var url = httpContext.Request.Path.Value;
            if (!url.Contains("/Callback"))
            {
                if (httpContext.Session.GetInt32("UserId") == null)
                    httpContext.Request.Path = "/Error/Error401";
                if (httpContext.Session.GetInt32("UserRole") == null)
                    httpContext.Request.Path = "/Error/Error401";
                if (httpContext.Session.GetString("Username") == null)
                    httpContext.Request.Path = "/Error/Error401";
            }
            return _next(httpContext);
        }
    }
}
