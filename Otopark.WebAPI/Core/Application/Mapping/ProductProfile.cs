using AutoMapper;
using Otopark.WebAPI.Core.Application.Dto;
using Otopark.WebAPI.Core.Domain;

namespace Otopark.WebAPI.Core.Application.Mapping
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            this.CreateMap<Product, ProductListDto>().ReverseMap();
        }
    }
}
