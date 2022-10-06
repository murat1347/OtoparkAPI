using MediatR;
using Otopark.WebAPI.Core.Application.Dto;

namespace Otopark.WebAPI.Core.Features.CQRS.Queries
{
    public class GetAllProductsQueryRequest:IRequest<List<ProductListDto>>
    {

    }
}
