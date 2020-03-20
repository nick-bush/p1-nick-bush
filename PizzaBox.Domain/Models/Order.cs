using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Order : AOrder
  {
    public long OId
    {
      get; set;
    }

    public override User usr
    {
      get; set;
    }

    public override Store str
    {
      get; set;
    }

    // public Date orderDate 
    // {
        //How can I use date objects in C#??
    // }

    public override decimal cost
    {
      get; set;
    }

    public override List<Pizza> Pizzas
    {
       get; set;
    }

    public Order() // commenting this out to get database set up User usr, Store str)
    {
      // this.usr = usr;
      // this.str = str;
      // pizzaList = new List<Pizza>();
      // cost = 0;

    }



    public override string ToString()
    {
      return $"{OId} {usr.username} {str.location ?? "N/A"} {cost}";
    }
  }
}