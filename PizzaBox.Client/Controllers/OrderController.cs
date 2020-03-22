using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Client.Models;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Controllers
{
  public class OrderController : Controller
  {
    private static readonly OrderRepository _or = new OrderRepository();
    private static readonly PizzaRepository _pr = new PizzaRepository();
    private static StoreRepository _sr = new StoreRepository();
    public static List<Pizza> PizzaList = new List<Pizza>();

    public static List<Store> StoreList = _sr.GetAllStores();

    public static List<string> StoreNameList = new List <string>();

    
    public static List<PizzaModel> PizzaModelList = new List<PizzaModel>();

    public static string UN = "";
    [HttpGet]
    public IActionResult Details()
    {
      return View();
    }

    // [HttpGet]
    // public IActionResult SelectStore(string Username)
    // {
    // }


    [HttpGet]
    public IActionResult Checkout()
    {
      Order o = new Order();
      o.cost = 0.00M;
      foreach(var p in PizzaList)
      {
        p.ord = o;
        o.cost = o.cost + p.cost;
      }
      o.Pizzas = PizzaList; 
      _or.Post(o);
      foreach(var p in o.Pizzas)
      {
        _pr.Post(p);
      }   
      return View();
    }

    [HttpGet]
    public IActionResult Add()
    {
      return View(new PizzaModel());
    }

    [HttpPost]
    public IActionResult Add(PizzaModel pmod)
    {
      if(ModelState.IsValid)
      {
        Pizza p = new Pizza();

        foreach(var c in pmod.CrustList)
        {
          if(pmod.Crust == c.Name)
          {
            p.crust = c;
          }
        }

        foreach(var s in pmod.SizeList)
        {
          if(pmod.Size == s.Name)
          {
            p.size = s;
          }
        }
        p.cost = p.crust.Price + p.size.Price;   
        pmod.cost = p.cost;
        PizzaList.Add(p);
        PizzaModelList.Add(pmod);
        
        return View("Details", PizzaModelList);
      }
      return View("Add", pmod);
    }

    
  }
}