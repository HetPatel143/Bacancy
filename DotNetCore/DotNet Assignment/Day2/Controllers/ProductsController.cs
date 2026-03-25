using Day2.DTO;
using Day2.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Day2.Controllers
{
    [ApiController]
    [Route("api/products")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;
        }


        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }
        
        
        [Authorize]
        [HttpGet("{id:int}")]        
        public IActionResult GetById(int id)
        {
            var product = _service.GetById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }
        
        
        [HttpGet("category/{name}")]        
        public IActionResult GetByCategory(string name)
        {
            return Ok(_service.GetByCategory(name));
        }


        [Authorize(Roles ="Admin,Vendor")]
        [HttpPost]        
        public IActionResult Create(ProductCreateDto dto)
        {
            var userid = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var created = _service.Add(dto,userid);
            return Ok(created);
        }


        [Authorize(Roles = "Admin,Vendor")]
        [HttpPut("{id:int}")]        
        public IActionResult Update(int id, ProductUpdateDto dto)
        {
            var userid = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var role = User.FindFirst(ClaimTypes.Role)!.Value;

            var updated = _service.Update(id, dto,userid,role);
            if (!updated) return Forbid();

            return NoContent();
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]        
        public IActionResult Delete(int id)
        {
            var userid = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var role = User.FindFirst(ClaimTypes.Role)!.Value;
            var removed = _service.Delete(id,userid,role);
            if (!removed) return NotFound();
            return NoContent();
        }
    }
}