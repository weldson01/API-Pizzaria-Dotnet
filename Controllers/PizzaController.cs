using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzariaAPI.context;

namespace PizzariaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        PizzariaContext _context;

        public PizzaController(PizzariaContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Ready()
        {
            return Ok("Ready");
        }

        [HttpGet]
        public IActionResult ShowPizzas()
        {
            var result = _context.pizzas.ToList();

            return Ok(result);
        }

    }
}