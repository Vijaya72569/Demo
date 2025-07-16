namespace DbProductService.Models
{
    public class Products
    {
        public int Id { get; set; }         // Primary Key
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }
}
