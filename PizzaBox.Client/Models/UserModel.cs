using System.ComponentModel.DataAnnotations;

namespace PizzaBox.Client.Models
{
  public class UserModel
  {
    [Required(ErrorMessage = "Please enter your username")]
    public string Username {get; set;}

    [Required(ErrorMessage = "Please enter your username")]
    public string Password {get; set;}
  }
}