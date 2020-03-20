using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class Store
  {
    public long SId { get; set; }

    public string username{get; set;}

    public string password{get; set;}

    public string location{get; set;}

    public List<Order> Orders { get; set; }


    public Store()
    {
      
    }
    
  }
}