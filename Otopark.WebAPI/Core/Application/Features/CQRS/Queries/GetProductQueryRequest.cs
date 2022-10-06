using MediatR;
using Otopark.WebAPI.Core.Application.Dto;

namespace Otopark.WebAPI.Core.Application.Features.CQRS.Queries
{
    public class GetProductQueryRequest : IRequest<ProductListDto>
    {
        public int Id { get; set; }
        public GetProductQueryRequest(int id)
        {
            Id = id;
        }
    }
}
