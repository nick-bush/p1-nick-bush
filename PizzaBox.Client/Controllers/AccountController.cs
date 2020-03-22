using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controllers
{
  public class AccountController : Controller
  {
    [HttpGet]
    public IActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Login(AccountModel account)
    {
      if(account.isUser == true)
      {
        foreach(var u in account.UserList)
        {
          if(account.Username == u.username)
          {
            return View("User", account);
          }
          else
          {
            return View();
          }
        }
      }
      else
      {
        foreach(var s in account.StoreList)
        {
          if(account.Username == s.username)
          {
            return View("Store");
          }
          else
          {
            return View();
          }
        }
      }
      return View();
    }
  }
}