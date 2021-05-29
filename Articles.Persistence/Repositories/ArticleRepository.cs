using Articles.Application.Contracts.Persistence;
using Articles.Domain;

namespace Articles.Persistence.Repositories
{
    class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(ArticlesDbContext dbContext) : base(dbContext)
        {
        }
    }
}
