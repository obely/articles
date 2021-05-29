using Articles.Application.Contracts.Persistence;
using Articles.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Articles.Persistence
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ArticlesDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ArticlesConnectionString")));

            services.AddScoped<IArticleRepository, ArticleRepository>();

            return services;
        }
    }
}
