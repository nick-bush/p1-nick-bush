using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Models
{
  public class OrderModel
  {
    public List<PizzaModel> PizzaModelList = new List<PizzaModel>();

    public User User { get; set; }
    public Store Store{get; set;}

    public decimal cost { get; set; }

  }
}