using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Controllers
{
  public class OrderController : Controller
  {
    public OrderModel or = new OrderModel();

    [HttpGet]
    public IActionResult Details()
    {
      return View();
    }

    [HttpGet]
    public IActionResult Add()
    {
      return View(new PizzaModel());
    }
    [HttpPost]
    public IActionResult Add(PizzaModel pizza)
    {
      if(ModelState.IsValid)
      {
        Pizza p = new Pizza();
        p.crust = pizza.Crust;
        p.size = pizza.Size;

        or.PizzaList.Add(p);
   
        
        return RedirectToAction("Details", or);
      }
      return View("Add", pizza);
    }

    [HttpGet]
    public IActionResult UserOptions()
    {
      return View();
    }

    // [HttpPost]
    // public IActionResult Remove(PizzaModel pizza)
    // {

    // }
  }
}