using MediatR;
using Otopark.WebAPI.Core.Application.Dto;

namespace Otopark.WebAPI.Core.Application.Features.CQRS.Queries
{
    public class GetCategoriesQueryRequest: IRequest<List<CategoryListDto>>
    {
    }
}
