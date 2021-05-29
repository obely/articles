using MediatR;
using System;

namespace Articles.Application.Articles.Commands.DeleteArticle
{
    public class DeleteArticleCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
