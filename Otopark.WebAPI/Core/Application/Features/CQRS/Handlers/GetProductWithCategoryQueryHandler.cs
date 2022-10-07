using AutoMapper;
using MediatR;
using Otopark.WebAPI.Core.Application.Dto;
using Otopark.WebAPI.Core.Application.Features.CQRS.Queries;
using Otopark.WebAPI.Core.Application.Interfaces;
using Otopark.WebAPI.Core.Domain;

namespace Otopark.WebAPI.Core.Application.Features.CQRS.Handlers
{
    public class GetProductWithCategoryQueryHandler : IRequestHandler<GetProductWithCategoryQueriesRequest,List<Product>>
    {
        private readonly IRepository<Category> _repository;
        private readonly IRepository<Product> _productList;
        private readonly IMapper _mapper;

        public GetProductWithCategoryQueryHandler(IRepository<Category> repository, IRepository<Product> productList, IMapper mapper)
        {
            _repository = repository;
            _productList = productList;
            _mapper = mapper;
        }

        public async Task<List<Product>> Handle(GetProductWithCategoryQueriesRequest request, CancellationToken cancellationToken)
        {
            var Categoryresult = await _repository.GetByIdAsync(request.Id);
            var productslist = await _productList.GetAllAsync();
            if(Categoryresult != null)
            {
                return productslist.Where(x => x.CategoryId == Categoryresult.Id).ToList();
                 
            }
            return null;
        }
    }
}
