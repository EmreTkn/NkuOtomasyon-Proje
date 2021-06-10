using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using API.Errors;
using API.Extensions;
using Core.Entities;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace API.Middleware
{
    public class SecurityMiddleware
    {
        private readonly RequestDelegate _next;
        public SecurityMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.Value.StartsWith("/api/studentaffairs/"))
            {
                Types role = Types.Student;
                var type = context.User?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value;
                if (type != null)
                {
                    role = (Types)Enum.Parse(typeof(Types), type);
                }

                if ((role != Types.StudentAffairs))
                {
                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                    var response = new ApiException(401,"Bu sayfaya yalnızca Admin kullanıcı ulaşabilir.");
                    var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                    var json = JsonSerializer.Serialize(response, options);

                    await context.Response.WriteAsync(json);
                }
                else
                {
                    await _next(context);
                }
            }
            else
            {
                await _next(context);
            }
            

        }
    }
}
