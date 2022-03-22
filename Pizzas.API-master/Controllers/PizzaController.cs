using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Models;

namespace Pizzas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Pizza> GetAll()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Pizza
            {
                Descripcion = "Con salsa de tomate y queso",
                Id = 1,
                Importe = 300,
                LibreGluten = false,
                Nombre = "Muzza Individual"
            })
            .ToArray();
        }
        [HttpGet("{id}")]
        public IActionResult<Pizza> GetById(int id){
            Pizza pizza = Bd.GetById(id);
            if(pizza == null){
                return NotFound();
            }
            return pizza;

        }
        [HttpPost]
        public IActionResult Create(Pizza pizza){
            Bd.Add(pizza);
            return CreatedAtAction(nameof(create), new { id = pizza.Id},pizza);

        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza){
            if(id != pizza.Id){
                return BadRequest();
            }
            Pizza pizzaExistente = Bd.Get(id);
            if(pizzaExistente is null){
                return NotFound();
            }
            Bd.Update(pizza);
            return Ok();

        }
        [HttpDelete("{id}")]
        public IAction DeleteBy(int id){

        }

    }
}
