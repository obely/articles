using Articles.Application.Contracts.Persistence;
using Articles.Application.Exceptions;
using Articles.Domain;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Articles.Application.Articles.Commands.UpdateArticle
{
    class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand>
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _articleRepository;

        public UpdateArticleCommandHandler(IMapper mapper, IArticleRepository articleRepository)
        {
            _mapper = mapper;
            _articleRepository = articleRepository;
        }

        public async Task<Unit> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var articleToUpdate = await _articleRepository.GetByIdAsync(request.Id);

            if (articleToUpdate == null)
            {
                throw new NotFoundException(nameof(Article), request.Id);
            }

            _mapper.Map(request, articleToUpdate, typeof(UpdateArticleCommand), typeof(Article));

            await _articleRepository.UpdateAsync(articleToUpdate);

            return Unit.Value;
        }
    }
}
