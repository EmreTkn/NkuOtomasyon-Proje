using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using API.Errors;
using Core.Entities;

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
                var type = context.User?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value;
                var role = (Types)Enum.Parse(typeof(Types), type ?? string.Empty);
                if ((role != Types.StudentAffairs))
                {
                    var json = JsonException(context);
                    await context.Response.WriteAsync(json);
                }
                else
                {
                    await _next(context);
                }
            }else if (context.Request.Path.Value.StartsWith("/api/teacher/"))
            {
                var type = context.User?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value;
                var role = (Types)Enum.Parse(typeof(Types), type ?? string.Empty);
                if (role != Types.Teacher)
                {
                    var json = JsonException(context);
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

        private static string JsonException(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

            var response = new ApiResponse(401, "Bu sayfaya ulaşmak için gerekli yetkiye sahip değilsiniz.");
            var options = new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

            var json = JsonSerializer.Serialize(response, options);
            return json;
        }
    }
}
