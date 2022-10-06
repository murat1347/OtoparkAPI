using AutoMapper;
using Otopark.WebAPI.Core.Application.Dto;
using Otopark.WebAPI.Core.Domain;

namespace Otopark.WebAPI.Core.Application.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            this.CreateMap<Category, CategoryListDto>().ReverseMap();
        }
    }
}


