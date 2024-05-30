using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzariaAPI.context;
using PizzariaAPI.model;

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
        public IActionResult ShowPizzas()
        {
            var result = _context.pizzas.ToList();
            if (result == null)
            {
                return BadRequest("We can not find pizzas.");
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddPizza(Pizza pizza)
        {
            var result = _context.Add(pizza);

            if (result == null)
            {
                return BadRequest();
            }

            _context.SaveChanges();
            return Ok(pizza);
        }

        [HttpPut]
        public IActionResult EditPizza(Pizza pizza)
        {
            _context.Update(pizza);
            _context.SaveChanges();

            return Ok("Have a slice of pizza");
        }

        [HttpDelete]
        public IActionResult DeletePizza(int id)
        {
            var pizza = _context.pizzas.Find(id);

            if (pizza == null)
                return NotFound("not found");

            _context.pizzas.Remove(pizza);
            _context.SaveChanges();
            
            return Ok("Success");
        }
    }
}