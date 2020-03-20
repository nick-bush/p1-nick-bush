using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
  public abstract class AOrder
  {
    public abstract User usr
    {
      get;
      set;
    }

    public abstract Store str
    {
      get;
      set;
    }

    // public Date orderDate 
    // {
        //How can I use date objects in C#??
    // }

    public abstract decimal cost
    {
      get;
      set;
    }

    public abstract List<Pizza> Pizzas
    {
      get;
      set;
    }

  }
}