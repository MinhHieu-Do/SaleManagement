using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.SaleManagement.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareErr
    { 
        private readonly RequestDelegate _next;
        

        public MiddlewareErr(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Response.StatusCode == StatusCodes.Status404NotFound)
            {                 
                httpContext.Response.Redirect("https://localhost:44325/ErrorPage/404");
            }    
            return _next(httpContext);
        }

       
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddlewareErr(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareErr>();
        }
    }
}
