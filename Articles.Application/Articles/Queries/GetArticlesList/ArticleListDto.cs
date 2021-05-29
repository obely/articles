using System;

namespace Articles.Application.Articles.Queries.GetArticlesList
{
    public class ArticleListDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
    }
}
