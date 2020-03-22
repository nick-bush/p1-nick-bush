using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Models
{
  public class AccountModel
  {
    private static UserRepository _ur = new UserRepository();
    private static StoreRepository _sr = new StoreRepository();
    public List<User> UserList = new List<User>();
    public List<Store> StoreList = new List<Store>();

    [BindProperty]
    public string Username { get; set; } 
    [BindProperty] 
    public string Password { get; set; }
    [BindProperty]
    public bool isUser { get; set; }

    public AccountModel()
    {
      UserList = _ur.GetAllUsers();
      StoreList = _sr.GetAllStores();
    }
  }
}