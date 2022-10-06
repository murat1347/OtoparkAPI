namespace Otopark.WebAPI.Core.Application.Dto
{
    public class ProductListDto
    {
        public int Id { get; set; }

        public string? ParkSlot { get; set; }

        public bool? IsFull { get; set; }

        public int CategoryId { get; set; }

       
    }
}
