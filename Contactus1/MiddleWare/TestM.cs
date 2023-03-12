using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Contactus1.MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TestM
    {
        private readonly RequestDelegate _next;

        public TestM(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("Custom", "Amirhossein");
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class TestMExtensions
    {
        public static IApplicationBuilder UseTestM(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TestM>();
        }
    }
}
