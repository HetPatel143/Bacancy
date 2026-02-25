using System.ComponentModel.DataAnnotations;

namespace Day2.DTO
{
    public class ProductUpdateDto
    {
        [Required, MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required, MaxLength(50)]
        public string Category { get; set; } = string.Empty;
        [Range(1, 100000)]
        public decimal Price { get; set; }
    }
}
