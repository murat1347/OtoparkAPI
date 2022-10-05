namespace Otopark.WebAPI.Core.Domain
{
    public class Product
    {
        public int Id { get; set; }

        public string? ParkSlot { get; set; }
        
        public bool? IsFull { get; set; }
       
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public Product()
        {
            Category = new Category();
        }
    }
}
