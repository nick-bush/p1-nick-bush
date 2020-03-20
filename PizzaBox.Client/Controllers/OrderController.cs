using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
  public class OrderController : Controller
  {
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
        //add to the Pizzalist
        
        return RedirectToAction("Details");
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