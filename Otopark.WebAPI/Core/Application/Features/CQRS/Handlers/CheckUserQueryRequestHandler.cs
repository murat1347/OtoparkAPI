using MediatR;
using Otopark.WebAPI.Core.Application.Dto;
using Otopark.WebAPI.Core.Application.Features.CQRS.Queries;
using Otopark.WebAPI.Core.Application.Interfaces;
using Otopark.WebAPI.Core.Domain;

namespace Otopark.WebAPI.Core.Application.Features.CQRS.Handlers
{
    public class CheckUserQueryRequestHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
    {
        private readonly IRepository<AppUser> _userRepository;
        private readonly IRepository<AppRole> _approleRepository;

        public CheckUserQueryRequestHandler(IRepository<AppUser> userRepository, IRepository<AppRole> approleRepository)
        {
            _userRepository = userRepository;
            _approleRepository = approleRepository;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();
            var user = await _userRepository.GetByFilter(x => x.UserName == request.Username && x.Password == request.Password);
            if (user == null)
            {
                dto.IsExist = false;
            }
            else
            {
                dto.Username = user.UserName;
                dto.Id = user.Id;
                dto.IsExist = true;
                var role = await _approleRepository.GetByFilter(x => x.Id == user.AppRoleId);
                dto.Role = role?.Defination;
            }

            return dto;
        }
    }
}
