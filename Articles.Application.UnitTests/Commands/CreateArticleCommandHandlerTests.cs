using Articles.Application.Articles.Commands.CreateArticle;
using Articles.Application.Contracts.Persistence;
using Articles.Application.Profiles;
using Articles.Domain;
using AutoMapper;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Articles.Application.UnitTests.Commands
{
    public class CreateArticleCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IArticleRepository> _mockArticleRepository;

        public CreateArticleCommandHandlerTests()
        {
            _mockArticleRepository = RepositoryMocks.GetArticleRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task CreateArticleCommandTest()
        {
            var handler = new CreateArticleCommandHandler(_mapper, _mockArticleRepository.Object);

            var id = await handler.Handle(new CreateArticleCommand { Title = "Test", Body = "Test" }, CancellationToken.None);

            _mockArticleRepository.Verify(r => r.AddAsync(It.IsAny<Article>()), Times.Once);

            Assert.NotEqual(Guid.Empty, id);
        }
    }
}
