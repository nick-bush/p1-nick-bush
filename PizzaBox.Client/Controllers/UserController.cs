using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
  public class UserController : Controller
  {
    [HttpGet]
    public IActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Login(UserModel user)
    {
      //some code in the User business object checks our login

      //if correct, redirect to action UserOptions

      //if incorrect, give an incorrect message

      return View(); // change this later
    }

    [HttpGet]
    public IActionResult UserOptions()
    {
      return View();
    }
  }
}
