using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Models
{
  public class PizzaModel
  { 
    private static PizzaRepository _pr = new PizzaRepository();
    public List<Crust> CrustList = new List<Crust>();
    public List<Size> SizeList = new List<Size>();
    
    public List<Type> TypeList = new List<Type>();

    public User User {get; set;}

    [BindProperty]
    public string Crust { get; set; }

    [BindProperty]
    public string Size { get; set; }

    [BindProperty]
    public string Type { get; set; }

    public decimal cost {get; set;}

    //public string Type {get; set;}

    public PizzaModel()
    {
      CrustList = _pr.GetAllCrusts();
      SizeList = _pr.GetAllSizes();
      TypeList = _pr.GetAllTypes();
    }
  }
}