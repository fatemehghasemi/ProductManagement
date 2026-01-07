using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Domain.Factories;
using Domain.Services;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductDbContext>(options =>
                 options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnectionString"),
                        sqlOptions => sqlOptions.MigrationsAssembly("Infrastructure") 
         ));

            // Register repositories
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductPriceRepository, ProductPriceRepository>();
            services.AddScoped<IProductAdtRepository, ProductAdtRepository>();
            services.AddScoped<IProductMaterialRepository, ProductMaterialRepository>();
            services.AddScoped<IProductSizeRepository, ProductSizeRepository>();
            services.AddScoped<IProductDeliverRepository, ProductDeliverRepository>();
            services.AddScoped<IProductPrintKindRepository, ProductPrintKindRepository>();
            services.AddScoped<IProductAdtTypeRepository, ProductAdtTypeRepository>();
            services.AddScoped<IProductAdtPriceRepository, ProductAdtPriceRepository>();
            services.AddScoped<IProductMaterialAttributeRepository, ProductMaterialAttributeRepository>();
            services.AddScoped<IProductDeliverSizeRepository, ProductDeliverSizeRepository>();

            // Register Factory Pattern
            services.AddScoped<IEntityFactory<Domain.Entities.Product, ProductCreationModel>, ProductFactory>();

            // Register Strategy Pattern - Pricing Strategies
            services.AddScoped<IPricingStrategy, StandardPricingStrategy>();
            services.AddScoped<IPricingStrategy, PremiumPricingStrategy>();
            
            return services;
        }
    }
}
