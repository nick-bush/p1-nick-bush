using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
  public abstract class APizza
  {
    public abstract Order ord
    {
      get; 
      set;
    }

    public abstract decimal cost
    {
      get;
      set;
    }

    public abstract Crust crust
    {
      get;
      set;
    }
    public abstract Size size
    {
      get;
      set;
    }
    //public abstract List<string> toppings
    // {
    //   get;
    //   set;
    // }


  }
}