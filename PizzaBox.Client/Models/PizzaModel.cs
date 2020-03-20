using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Models
{
  public class PizzaModel
  { 
    private static PizzaRepository _pr = new PizzaRepository();
    public List<Crust> CrustList = new List<Crust>();
    public List<Size> SizeList = new List<Size>();
    //public List<string> TypeList = new List<string>();
    public Crust Crust { get; set; }

    public Size Size { get; set; }

    //public string Type {get; set;}

    public PizzaModel()
    {
      CrustList = _pr.GetAllCrusts();
      SizeList = _pr.GetAllSizes();
    }
  }
}