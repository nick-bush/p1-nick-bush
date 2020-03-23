using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Models
{
  public class StoreModel
  {
    private static StoreRepository _sr = new StoreRepository();
    public List<Store> StoreList = new List<Store>();

    public string username{ get; set; }
    
    public StoreModel()
    {
      StoreList = _sr.GetAllStores();
    }
  }
}