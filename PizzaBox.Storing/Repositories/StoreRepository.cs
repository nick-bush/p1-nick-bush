using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Databases;

namespace PizzaBox.Storing.Repositories
{
  public class StoreRepository
  {
    private static readonly PizzaBoxDbContext _db = PizzaBoxDbContext.Instance;

    private Store AuthenticatedStore { get; set; }
    
    public Store GetStore(long id)
    {
      return _db.Stores.SingleOrDefault(s => s.SId == id);
    }

    public Store GetStoreWithUsername(string username)
    {
      AuthenticatedStore =  _db.Stores.SingleOrDefault(s => s.username == username);
      return AuthenticatedStore;
    }
    public List<Store> GetAllStores()
    { 
      return _db.Stores.ToList();   
    }
  }
}