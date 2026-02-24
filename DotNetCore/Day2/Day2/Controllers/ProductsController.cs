using Day2.Interfaces;
using Day2.Models;
using Day2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day2.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

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

        [HttpPost]
        public IActionResult Create(Product product)
        {
            var created = _service.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var removed = _service.Delete(id);
            if (!removed) return NotFound();
            return NoContent();
        }
    }
}