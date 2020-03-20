using Microsoft.AspNetCore.Mvc;

namespace PizzaBox.Client.Controllers
{
  public class StoreController : Controller
  {
    [HttpGet]
    public IActionResult Store()
    {
      return View();//return navigation page that can direct to either StoreHistory or StoreSales
    }
  }
}