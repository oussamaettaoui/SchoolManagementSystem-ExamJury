using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Application.IRepositories;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Infrastructure.Repositories;
using SchoolManagementSystem.Infrastructure.UnitOfWorks;

namespace SchoolManagementSystem.Infrastructure
{
    public static class InfrastructureContainer
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            string? conn = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(option=>option.UseSqlServer(conn));
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<IJuryMemberRepository,JuryMemberRepository>();
            return services;
        }
    }
}
