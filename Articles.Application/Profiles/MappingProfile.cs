using Articles.Application.Articles.Commands.CreateArticle;
using Articles.Application.Articles.Commands.UpdateArticle;
using Articles.Application.Articles.Queries.GetArticle;
using Articles.Application.Articles.Queries.GetArticlesList;
using Articles.Domain;
using AutoMapper;

namespace Articles.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Article, ArticleListDto>();
            CreateMap<Article, ArticleDto>();

            CreateMap<Article, CreateArticleCommand>().ReverseMap();
            CreateMap<Article, UpdateArticleCommand>().ReverseMap();
        }
    }
}
