using WebApp.Models;

namespace WebApp
{
    public class TestMiddleware
    {
        private RequestDelegate _next;

        public TestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, DataContext dataContext)
        {
            if (httpContext.Request.Path == "/test")
            {
                await httpContext.Response.WriteAsync($"There are {dataContext.Products.Count()} products\n\n\n");
                await httpContext.Response.WriteAsync($"There are {dataContext.Categories.Count()} categories \n\n\n");
                await httpContext.Response.WriteAsync($"There are {dataContext.Suppliers.Count()} suppliers \n\n\n");
            }
            else
            {
                await _next(httpContext);
            }
        }
    }
}
