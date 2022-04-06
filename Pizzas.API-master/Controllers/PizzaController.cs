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
        public IActionResult GetAll()
        {
            List<Pizza> ListaPizzas = PizzasService.GetAll();
            return Ok(ListaPizzas);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id){
            Pizza pizza = PizzasService.GetById(id);
            if(pizza == null){
                return NotFound();
            }
            return Ok( pizza);

        }
        [HttpPost]
        public IActionResult Create(Pizza pizza){
            PizzasService.Insert(pizza);
            return Ok(pizza);

        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza){
            if(id != pizza.Id){
                return BadRequest();
            }
            Pizza pizzaExistente = PizzasService.GetById(id);
            if(pizzaExistente is null){
                return NotFound();
            }
            PizzasService.UpdateById(id,pizza);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBy(int id){
            Pizza pizza = PizzasService.GetById(id);
            if (pizza == null){
                return NotFound();
            }
            PizzasService.DeleteBy(id);
            return Ok();
        }

    }
}
