using Articles.Application.Contracts.Persistence;
using Articles.Application.Exceptions;
using Articles.Domain;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Articles.Application.Articles.Queries.GetArticle
{
    class GetArticleQueryHandler : IRequestHandler<GetArticleQuery, ArticleDto>
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _articleRepository;

        public GetArticleQueryHandler(IMapper mapper, IArticleRepository articleRepository)
        {
            _mapper = mapper;
            _articleRepository = articleRepository;
        }

        public async Task<ArticleDto> Handle(GetArticleQuery request, CancellationToken cancellationToken)
        {
            var article = await _articleRepository.GetByIdAsync(request.Id);

            if (article == null)
            {
                throw new NotFoundException(nameof(Article), request.Id);
            }

            return _mapper.Map<ArticleDto>(article);
        }
    }
}
