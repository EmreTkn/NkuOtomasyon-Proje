using System.Linq;
using API.Errors;
using Core.Entities;
using Core.Entities.Identity;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Identity;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService,TokenService>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppIdentityContext>();
<<<<<<< HEAD
            //services.AddIdentity<Student,IdentityRole>().AddEntityFrameworkStores<NkuContext>();
           
=======
>>>>>>> e4f5a0a46ad59d13fdd51563771133ef2fe70332
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;
        }
    }
}
