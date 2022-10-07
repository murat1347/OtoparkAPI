using MediatR;
using Otopark.WebAPI.Core.Application.Dto;
using Otopark.WebAPI.Core.Domain;

namespace Otopark.WebAPI.Core.Application.Features.CQRS.Queries
{
    public class GetProductWithCategoryQueriesRequest:IRequest<List<Product>>
    {
        public int Id { get; set; }
        public GetProductWithCategoryQueriesRequest(int id)
        {
            Id = id;
        }
    }
}
