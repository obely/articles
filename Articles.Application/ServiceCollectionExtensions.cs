using Articles.Application.Articles.Commands.CreateArticle;
using Articles.Application.Articles.Commands.UpdateArticle;
using Articles.Application.Articles.Queries.GetArticlesList;
using Articles.Application.PipelineBehaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Articles.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient<IValidator<GetArticlesListQuery>, GetArticlesListQueryValidator>();
            services.AddTransient<IValidator<CreateArticleCommand>, CreateArticleCommandValidator>();
            services.AddTransient<IValidator<UpdateArticleCommand>, UpdateArticleCommandValidator>();

            return services;
        }
    }
}
