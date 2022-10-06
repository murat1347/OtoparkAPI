using MediatR;
using Otopark.WebAPI.Core.Application.Dto;

namespace Otopark.WebAPI.Core.Application.Features.CQRS.Queries
{
    public class GetCategoryQueryRequest: IRequest<CategoryListDto>
    {
        public int Id { get; set; }
        public GetCategoryQueryRequest(int id)
        {
            Id = id;
        }
    }
}
