using Articles.Application.Contracts.Persistence;
using FluentValidation;

namespace Articles.Application.Articles.Queries.GetArticlesList
{
    class GetArticlesListQueryValidator : AbstractValidator<GetArticlesListQuery>
    {
        public GetArticlesListQueryValidator()
        {
            RuleFor(q => q.Sorting)
                .Must(BeValidSorting).WithMessage("{PropertyName} is not valid.");

            RuleFor(q => q.Pagination)
                .Must(BeValidPagination).WithMessage("{PropertyName} is not valid.");
        }

        private bool BeValidSorting(SortOptions options) => options == null || !string.IsNullOrWhiteSpace(options.SortKey);

        private bool BeValidPagination(PaginationOptions options) => options == null || options.Page > 0 && options.Size > 0;
    }
}
