using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Databases;

namespace PizzaBox.Storing.Repositories
{
  public class PizzaRepository
  {
    private static readonly PizzaBoxDbContext _db = PizzaBoxDbContext.Instance;

    public List<Crust> GetAllCrusts()
    {
      return _db.Crusts.ToList();
    }

    public List<Size> GetAllSizes()
    {
      return _db.Sizes.ToList();
    }
  } 
}