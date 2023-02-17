using api.Data;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[EnableCors("examplePolicy")]
[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{

    private readonly ApplicationDbContext _db;

    public PizzaController(ApplicationDbContext db)
    {
        _db = db;
    }



    // GET
    [HttpGet]
    public ActionResult<List<Pizza>> getAll()
    {
        return _db.Pizzas.ToList();

        //PizzaService.GetAll();
    }

    
    [HttpGet("{id}")]
    public ActionResult<Pizza> getPizza(int id)
    {
        //var pizza = PizzaService.Get(id);
        var pizza = _db.Pizzas.SingleOrDefault(x => x.Id == id);

        if(pizza == null)
            return NotFound();
        
        return pizza;

    }
   
    
    [HttpPost]
    public async Task<ActionResult> Create(Pizza pizza)
    {
        //PizzaService.Add(pizza);
        _db.Pizzas.Add(pizza);
        await _db.SaveChangesAsync();
        return Ok(pizza);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateItem(int id, Pizza pizza)
    {
        var pizzaToUpdate = await _db.Pizzas.FindAsync(id);

        if (pizzaToUpdate == null)
        {
            return NotFound();
        }

        //TODO: Fix the name field in the model (remove the ? and run migrations)
        pizzaToUpdate.Name = pizza.Name;
        pizzaToUpdate.IsGlutenFree = pizza.IsGlutenFree;
        pizzaToUpdate.createdAt= DateTime.Now;
        

        await _db.SaveChangesAsync();

        return Ok(pizzaToUpdate);
    }




    [HttpDelete("{id}")]
   public async Task<IActionResult> Delete(int id)
   {
       var pizza = await _db.Pizzas.FindAsync(id);

       if (pizza is null)
           return NotFound();

       _db.Pizzas.Remove(pizza);
        await _db.SaveChangesAsync();

       return NoContent();
   }
   

}