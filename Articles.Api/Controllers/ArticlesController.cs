using Articles.Application.Articles.Commands.CreateArticle;
using Articles.Application.Articles.Commands.DeleteArticle;
using Articles.Application.Articles.Commands.UpdateArticle;
using Articles.Application.Articles.Queries.GetArticle;
using Articles.Application.Articles.Queries.GetArticlesList;
using Articles.Application.Contracts.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Articles.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : Controller
    {
        private readonly IMediator _mediator;

        public ArticlesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetAllArticles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ArticleListDto>>> GetAllArticles([FromQuery] SortOptions sortOptions, [FromQuery] PaginationOptions paginationOptions)
        {
            var dtos = await _mediator.Send(new GetArticlesListQuery { Sorting = sortOptions.IsEmpty ? null : sortOptions, Pagination = paginationOptions.IsEmpty ? null : paginationOptions });

            return Ok(dtos);
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetArticleById")]
        public async Task<ActionResult<ArticleDto>> GetArticleById(Guid id)
        {
            return Ok(await _mediator.Send(new GetArticleQuery { Id = id }));
        }

        [HttpPost(Name = "AddArticle")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateArticleCommand createArticleCommand)
        {
            var id = await _mediator.Send(createArticleCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateArticle")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateArticleCommand updateArticleCommand)
        {
            await _mediator.Send(updateArticleCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteArticle")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteArticleCommand() { Id = id });
            return NoContent();
        }
    }
}
