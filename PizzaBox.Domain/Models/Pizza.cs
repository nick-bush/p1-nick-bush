using System;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Pizza : APizza
  {

    public override Order ord
    {
      get; set;
    }

    public override decimal cost
    {
      get; set;
    }

    public Type type
    {
      get; set;
    }

    public override Crust crust
    {
      get; set;
    }
    public override Size size
    {
      get; set;
    }

    
    public long PId
    {
      get; set;
    }


    public Pizza()
    {
      //PId = DateTime.Now.Ticks;
    }
    public override string ToString()
    {
      return $"{PId} {crust.Name ?? "N/A"} {size.Name ?? "N/A"} {cost}";
    }
  }
}