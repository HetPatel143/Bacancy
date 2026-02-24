using Day2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Day2.Controllers
{
    [ApiController]
    [Route("api/lifetime")]
    public class LifetimeController : ControllerBase
    {
        private readonly ITransientService _transient1;
        private readonly ITransientService _transient2;

        private readonly IScopedService _scoped1;
        private readonly IScopedService _scoped2;

        private readonly ISingletonService _singleton1;
        private readonly ISingletonService _singleton2;

        public LifetimeController(
            ITransientService transient1,
            ITransientService transient2,
            IScopedService scoped1,
            IScopedService scoped2,
            ISingletonService singleton1,
            ISingletonService singleton2)
        {
            _transient1 = transient1;
            _transient2 = transient2;
            _scoped1 = scoped1;
            _scoped2 = scoped2;
            _singleton1 = singleton1;
            _singleton2 = singleton2;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                transient1 = _transient1.Id,
                transient2 = _transient2.Id,

                scoped1 = _scoped1.Id,
                scoped2 = _scoped2.Id,

                singleton1 = _singleton1.Id,
                singleton2 = _singleton2.Id
            });
        }
    }
}