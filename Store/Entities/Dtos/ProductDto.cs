using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ProductDto
    {
        public int ProductId { get; init; }
        [Required(ErrorMessage = "Product Name is Required.")]
        public string? ProductName { get; init; } = string.Empty;
        [Required(ErrorMessage = "Product Price is Required.")]

        public decimal Price { get; init; }
        public int? CategoryId { get; init; }
        public String? Summary { get; init; } = String.Empty;
        public String? ImageUrl { get; set; }


    }

}