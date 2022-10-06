namespace Otopark.WebAPI.Core.Application.Dto
{
    public class CategoryListDto
    {
        public int Id { get; set; }
        public String? Defination { get; set; }
        
        public ProductListDto productList { get; set; }
    }
}
