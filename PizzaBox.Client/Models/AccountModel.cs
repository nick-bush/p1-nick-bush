using Microsoft.AspNetCore.Mvc;

namespace PizzaBox.Client.Models
{
  public class AccountModel
  {
    [BindProperty]
    public string Username { get; set; } 
    [BindProperty] 
    public string Password { get; set; }
    public bool isUser { get; set; }
  }
}