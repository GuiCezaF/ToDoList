using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Application.Mapping;
using ToDoList.Application.Services;
using ToDoList.Application.Services.Interfaces;
using ToDoList.Domain.Repositories.Interfaces;
using ToDoList.Infra.Data.context;
using ToDoList.Infra.Data.Repositories;

namespace ToDoList.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ToDoDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("ToDoList.API")));

            services.AddScoped<IToDoRepository, ToDoRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            services.AddScoped<IToDoService, ToDoService>();

            return services;
        }
    }
}