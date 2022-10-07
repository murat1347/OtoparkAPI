using Otopark.WebAPI.Core.Domain;

namespace Otopark.WebAPI.Core.Application.Dto
{
    public class CategoryWithProductDto
    {
        public int Id { get; set; }
        public List<Product>? products { get; set; }
    }
}
