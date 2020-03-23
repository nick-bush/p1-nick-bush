using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Databases;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaBox.Storing.Repositories
{
  public class OrderRepository
  {
    public OrderRepository()
    {

    }    

    private static readonly PizzaBoxDbContext _db= PizzaBoxDbContext.Instance;


    public bool Post(Order order)
    {
      _db.Orders.Add(order);
      return _db.SaveChanges() == 1;
    }

    public List<Order> UserOrderHistory(User user)
    {
      List<Order> orders = new List<Order>();
      List<Order> userOrders = new List<Order>();

      orders = _db.Orders.Include(o => o.usr).Include(o => o.str).ToList();
      
      if(orders != null)
      {
        foreach(var o in orders)
        {
          if(o.usr.UId == user.UId)
          {
            userOrders.Add(o);
          }
        }
        return userOrders;        
      }
      else if(userOrders == null){
        
        return null;
      }
      else
      {
        return null;
      }
    }
  }
}