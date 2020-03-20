using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;

namespace PizzaBox.Client.Controllers
{
  public class AccountController : Controller
  {
    [HttpGet]

    public IActionResult Login()
    {
      return View();
    }

    //[HttpPost]
    // public IActionResult Login(AccountModel account)
    // {
      
    // }
  }
}