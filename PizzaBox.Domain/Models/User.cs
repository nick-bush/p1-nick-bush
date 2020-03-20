using System.Collections.Generic;


namespace PizzaBox.Domain.Models
{
  public class User
  {
    public long UId { get; set; }

    public string username{get; set;}

    public string password{get; set;}

    public List<Order> Orders { get; set; }

    public User()
    {
      
    }
  }
}