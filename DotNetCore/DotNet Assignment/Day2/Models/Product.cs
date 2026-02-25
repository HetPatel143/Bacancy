using Day2.Interfaces;
using Day2.Services;
using System.ComponentModel.DataAnnotations;
namespace Day2.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50)]
        public string Category { get; set; }
        [Range(0.01,100000)]
        public decimal Price { get; set; }
    }
}
