using AutoMapper;
using MediatR;
using Otopark.WebAPI.Core.Application.Dto;
using Otopark.WebAPI.Core.Application.Features.CQRS.Queries;
using Otopark.WebAPI.Core.Application.Interfaces;
using Otopark.WebAPI.Core.Domain;

namespace Otopark.WebAPI.Core.Application.Features.CQRS.Handlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQueryRequest, ProductListDto>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductListDto> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByFilter(x=>x.Id == request.Id);
            return _mapper.Map<ProductListDto>(result);
        }
    }
}
