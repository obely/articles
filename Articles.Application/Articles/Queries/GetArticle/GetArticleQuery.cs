using MediatR;
using System;

namespace Articles.Application.Articles.Queries.GetArticle
{
    public class GetArticleQuery : IRequest<ArticleDto>
    {
        public Guid Id { get; set; }
    }
}
