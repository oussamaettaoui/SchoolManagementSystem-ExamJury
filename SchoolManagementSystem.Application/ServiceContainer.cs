using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagementSystem.Application.IServices;
using SchoolManagementSystem.Application.Services;
using SchoolManagementSystem.Application.UnitOfServices;
using SchoolManagementSystem.Application.UnitOfServices.Abstractions;

namespace SchoolManagementSystem.Application
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IJuryMemberService, JuryMemberService>();
            services.AddTransient<IMeetingService, MeetingService>();
            services.AddTransient<IJuryMemberRoleService, JuryMemberRoleService>();
            services.AddTransient<IJuryService, JuryService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IUnitOfService, UnitOfService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IDayOrderService, DayOrderService>();
            //configuration of mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            //configuration of auto mapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
