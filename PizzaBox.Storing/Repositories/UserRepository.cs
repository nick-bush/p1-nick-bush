using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Databases;

namespace PizzaBox.Storing.Repositories
{
  public class UserRepository
  {
    private static readonly PizzaBoxDbContext _db = PizzaBoxDbContext.Instance;

    private User AuthenticatedUser { get; set; }
    
    public User GetUser(long id)
    {
      return _db.Users.SingleOrDefault(u => u.UId == id);
    }

    public User GetUserWithUsername(string username)
    {
      AuthenticatedUser =  _db.Users.SingleOrDefault(u => u.username == username);
      return AuthenticatedUser;
    }
    public List<User> GetAllUsers()
    { 
      return _db.Users.ToList();   
    }   

  }
}