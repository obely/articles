using Articles.Domain;

namespace Articles.Application.Contracts.Persistence
{
    public interface IArticleRepository : IAsyncRepository<Article>
    {
    }
}
