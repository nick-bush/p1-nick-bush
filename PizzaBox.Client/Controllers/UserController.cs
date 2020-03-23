using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controllers
{
  public class UserController : Controller
  {
    private static readonly OrderRepository _or = new OrderRepository();
    private static UserRepository _ur = new UserRepository();
    
    
    [HttpGet]
    public IActionResult UserHistory()
    {
      List<Order> OrderList = new List<Order>();
      List<OrderModel> OrderModelList = new List<OrderModel>();
      User u = _ur.GetUserWithUsername(TempData["user"].ToString());
      OrderList = _or.UserOrderHistory(u);
      if(OrderList!= null)
      {
        ViewBag.Message = "Order History";
        foreach(var o in OrderList)
        {
          OrderModel om = new OrderModel();
        
          om.Store= o.str;
          om.cost = o.cost;
          OrderModelList.Add(om);
       
        }
        return View(OrderModelList);
      }
      else
      {
        ViewBag.Message = "You Have No Order History";
        return View();
      }
      
    }
  }
}
