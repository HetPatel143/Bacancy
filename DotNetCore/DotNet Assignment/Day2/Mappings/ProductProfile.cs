using Day2.Models;
using AutoMapper;
using Day2.DTO;
namespace Day2.Mappings
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, ProductReadDto>();
        }
    }
}
