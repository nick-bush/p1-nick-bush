using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
  public class OrderModel
  {
    public List<Pizza> PizzaList = new List<Pizza>();

    public User User { get; set; }
    public Store Store{get; set;}

    public decimal cost { get; set; }

  }
}