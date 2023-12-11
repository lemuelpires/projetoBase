using HelperStockBeta.Application.Interfaces;
using HelperStockBeta.Application.Mappings;
using HelperStockBeta.Application.Services;
using HelperStockBeta.Domain.Interface;
using HelperStockBeta.Infra.Data.Context;
using HelperStockBeta.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HelperStockBeta.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfraStructureAPI(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                options =>
                options.UseSqlServer(configuration.GetConnectionString("Default Connection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            // Mapeamento de DTOs
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
