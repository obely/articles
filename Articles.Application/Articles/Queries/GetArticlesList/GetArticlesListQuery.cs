using Articles.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;

namespace Articles.Application.Articles.Queries.GetArticlesList
{
    public class GetArticlesListQuery : IRequest<List<ArticleListDto>>
    {
        public PaginationOptions Pagination { get; set; }
        public SortOptions Sorting { get; set; }
    }
}
