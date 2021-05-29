using MediatR;
using System;

namespace Articles.Application.Articles.Commands.CreateArticle
{
    public class CreateArticleCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
