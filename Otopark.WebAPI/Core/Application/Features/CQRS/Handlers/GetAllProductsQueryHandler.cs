using AutoMapper;
using MediatR;
using Otopark.WebAPI.Core.Application.Dto;
using Otopark.WebAPI.Core.Application.Interfaces;
using Otopark.WebAPI.Core.Domain;
using Otopark.WebAPI.Core.Features.CQRS.Queries;

namespace Otopark.WebAPI.Core.Features.CQRS.Handlers
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, List<ProductListDto>>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<ProductListDto>>(data);
        }
    }
}
