using AutoMapper;
using MediatR;
using Otopark.WebAPI.Core.Application.Dto;
using Otopark.WebAPI.Core.Application.Features.CQRS.Queries;
using Otopark.WebAPI.Core.Application.Interfaces;
using Otopark.WebAPI.Core.Domain;

namespace Otopark.WebAPI.Core.Application.Features.CQRS.Handlers
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, List<CategoryListDto>>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;
        public GetCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CategoryListDto>> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByFilter(x => x.Id == request.Id);
            return _mapper.Map<CategoryListDto>(data);
        }
    }
}
