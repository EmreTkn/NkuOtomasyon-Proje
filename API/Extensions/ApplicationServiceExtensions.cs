using System;
using System.Linq;
using API.Errors;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService,TokenService>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IEmailSender, SmtpEmailSender>(i =>
                    new SmtpEmailSender(
                        config["EmailSender:Host"],
                        config.GetValue<int>("EmailSender:Port"),
                        config.GetValue<bool>("EmailSender:EnableSSL"),
                        config["EmailSender:UserName"],
                        config["EmailSender:Password"])
            );
            //services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AppIdentityContext>();

            //services.AddIdentity<Student,IdentityRole>().AddEntityFrameworkStores<NkuContext>();
            
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
