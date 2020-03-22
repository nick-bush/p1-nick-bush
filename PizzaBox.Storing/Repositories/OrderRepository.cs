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
  }
}