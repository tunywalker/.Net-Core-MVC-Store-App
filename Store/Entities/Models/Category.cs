namespace Entities.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public String? CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }

}