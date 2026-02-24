using Day2.Models;

namespace Day2.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        IEnumerable<Product> GetByCategory(string category);
        Product Add(Product product);
        bool Delete(int id);
    }
}