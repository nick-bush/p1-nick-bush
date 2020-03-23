using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Type : APizzaComponent
  {
    public long TypeId { get; set; }

    public List<Pizza> Pizzas { get; set; }

    public override string ToString()
    {
      return $"{Name ?? "N/A"} {Price}";
    }

    public Type()
    {
      
    }
  }
}