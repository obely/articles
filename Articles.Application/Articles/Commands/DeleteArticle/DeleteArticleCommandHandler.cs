using Articles.Application.Contracts.Persistence;
using Articles.Application.Exceptions;
using Articles.Domain;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Articles.Application.Articles.Commands.DeleteArticle
{
    class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand>
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _articleRepository;

        public DeleteArticleCommandHandler(IMapper mapper, IArticleRepository articleRepository)
        {
            _mapper = mapper;
            _articleRepository = articleRepository;
        }

        public async Task<Unit> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            var articleToDelete = await _articleRepository.GetByIdAsync(request.Id);

            if (articleToDelete == null)
            {
                throw new NotFoundException(nameof(Article), request.Id);
            }

            await _articleRepository.DeleteAsync(articleToDelete);

            return Unit.Value;
        }
    }
}
