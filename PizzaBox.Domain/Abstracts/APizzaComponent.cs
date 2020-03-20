using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
  public abstract class APizzaComponent
  {
    public string Name { get; set; }
    public decimal Price { get; set; }

    #region NAVIGATIONAL PROPERTIES

    public virtual Pizza Pizza { get; set; }

    #endregion
  }
}