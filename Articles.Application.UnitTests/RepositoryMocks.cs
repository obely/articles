using Articles.Application.Contracts.Persistence;
using Articles.Domain;
using Moq;
using System;
using System.Collections.Generic;

namespace Articles.Application.UnitTests
{
    public class RepositoryMocks
    {
        public static Mock<IArticleRepository> GetArticleRepository()
        {
            var articles = new List<Article>
            {
                new Article
                {
                     Id = Guid.NewGuid(),
                     Title = "My first article",
                     Body = "First article body",
                     Created = DateTime.Parse("2021-03-10")
                },
                new Article
                {
                     Id = Guid.NewGuid(),
                     Title = "My second article",
                     Body = "Second article body",
                     Created = DateTime.Parse("2021-02-15")
                },
                new Article
                {
                     Id = Guid.NewGuid(),
                     Title = "My third article",
                     Body = "Third article body",
                     Created = DateTime.Parse("2021-05-10")
                }
            };

            var mockArticleRepository = new Mock<IArticleRepository>();
            mockArticleRepository.Setup(repo => repo.GetPagedReponseAsync(It.IsAny<SortOptions>(), It.IsAny<PaginationOptions>())).ReturnsAsync(articles);

            mockArticleRepository.Setup(repo => repo.AddAsync(It.IsAny<Article>())).ReturnsAsync(
                (Article article) =>
                {
                    article.Id = Guid.NewGuid();
                    return article;
                });

            return mockArticleRepository;
        }
    }
}
