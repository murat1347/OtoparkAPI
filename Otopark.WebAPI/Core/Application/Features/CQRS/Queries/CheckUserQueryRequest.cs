using MediatR;
using Otopark.WebAPI.Core.Application.Dto;

namespace Otopark.WebAPI.Core.Application.Features.CQRS.Queries
{
    public class CheckUserQueryRequest: IRequest<CheckUserResponseDto>
    {


        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}
