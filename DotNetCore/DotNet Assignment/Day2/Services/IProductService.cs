using Day2.DTO;
using Day2.Models;

namespace Day2.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductReadDto> GetAll();
        ProductReadDto? GetById(int id);
        IEnumerable<ProductReadDto> GetByCategory(string category);
        ProductReadDto Add(ProductCreateDto dto);
        bool Update(int id, ProductUpdateDto dto);
        bool Delete(int id);
    }
}