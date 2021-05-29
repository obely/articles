using Articles.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Articles.Application.Articles.Queries.GetArticlesList
{
    public class GetArticlesListQueryHandler : IRequestHandler<GetArticlesListQuery, List<ArticleListDto>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _articleRepository;

        public GetArticlesListQueryHandler(IMapper mapper, IArticleRepository articleRepository)
        {
            _mapper = mapper;
            _articleRepository = articleRepository;
        }

        public async Task<List<ArticleListDto>> Handle(GetArticlesListQuery request, CancellationToken cancellationToken)
        {
            var articles = await _articleRepository.GetPagedReponseAsync(request.Sorting, request.Pagination);

            return _mapper.Map<List<ArticleListDto>>(articles);
        }
    }
}
