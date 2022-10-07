using AutoMapper;
using Otopark.WebAPI.Core.Application.Dto;
using Otopark.WebAPI.Core.Domain;

namespace Otopark.WebAPI.Core.Application.Mapping
{
    public class CategoryWithProductProfile : Profile
    {
        public CategoryWithProductProfile()
        {
            this.CreateMap<Category, CategoryWithProductDto>().ReverseMap();
        }
    }
}
