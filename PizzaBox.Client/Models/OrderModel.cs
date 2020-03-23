using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
  public class OrderModel
  {
    public User User { get; set; }
    public Store Store{get; set;}

    public decimal cost { get; set; }


  }
}