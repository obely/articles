using Articles.Application.Articles.Queries.GetArticlesList;
using Articles.Application.Contracts.Persistence;
using Articles.Application.Profiles;
using AutoMapper;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Articles.Application.UnitTests
{
    public class GetArticlesListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IArticleRepository> _mockArticleRepository;

        public GetArticlesListQueryHandlerTests()
        {
            _mockArticleRepository = RepositoryMocks.GetArticleRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetArticlesListTest()
        {
            var handler = new GetArticlesListQueryHandler(_mapper, _mockArticleRepository.Object);

            var list = await handler.Handle(new GetArticlesListQuery(), CancellationToken.None);

            _mockArticleRepository.Verify(r => r.GetPagedReponseAsync(It.IsAny<SortOptions>(), It.IsAny<PaginationOptions>()), Times.Once);

            Assert.Equal(3, list.Count);
        }
    }
}
