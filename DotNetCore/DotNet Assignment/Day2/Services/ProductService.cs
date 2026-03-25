using AutoMapper;
using Day2.Data;
using Day2.DTO;
using Day2.Interfaces;
using Day2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Data;

namespace Day2.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ProductService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<ProductReadDto> GetAll()
        {
            var products = _context.Products.AsNoTracking().ToList();
            return _mapper.Map<IEnumerable<ProductReadDto>>(products);
        }
        public ProductReadDto? GetById(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return null;
            return _mapper.Map<ProductReadDto>(product);
        }
        public IEnumerable<ProductReadDto> GetByCategory(string category)
        {
            var products = _context.Products.Where(p => p.Category.ToLower() == category.ToLower())
                                   .AsNoTracking().ToList();
            return _mapper.Map<IEnumerable<ProductReadDto>>(products);
        }
        public ProductReadDto Add(ProductCreateDto dto,Guid vendorId)
        {
            var product = _mapper.Map<Product>(dto);
            product.VendorId = vendorId;
            _context.Products.Add(product);
            _context.SaveChanges();
            return _mapper.Map<ProductReadDto>(product);
        }
        public bool Update(int id, ProductUpdateDto dto,Guid userid, string role)
        {
            var exist = _context.Products.Find(id);
            if (exist == null) return false;
            if(role=="Admin")
            {
                _mapper.Map(dto, exist);
                _context.SaveChanges();
                return true;
            }
            if(role=="Vendor" && exist.VendorId != userid)
            {
                return false;
            }
            _mapper.Map(dto, exist);
            _context.SaveChanges();
            return true;
        }
        public bool Delete(int id,Guid userid, string role)
        {
            var product = _context.Products.Find(id);
            if (product == null) return false;
            if (role == "Admin")
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}