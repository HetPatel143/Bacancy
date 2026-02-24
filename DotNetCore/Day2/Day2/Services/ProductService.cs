using Day2.Data;
using Day2.Interfaces;
using Day2.Models;
using Microsoft.EntityFrameworkCore;

namespace Day2.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetAll() =>_context.Products.ToList();
        public Product? GetById(int id) =>_context.Products.Find(id);
        public IEnumerable<Product> GetByCategory(string category) =>
            _context.Products.Where(p => p.Category.ToLower() == category.ToLower()).ToList();
        public Product Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public bool Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }
    }
}