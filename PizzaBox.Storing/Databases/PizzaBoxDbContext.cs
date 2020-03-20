using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Databases
{
  public class PizzaBoxDbContext : DbContext
  {
    private static readonly PizzaBoxDbContext _dbContext = new PizzaBoxDbContext();

    public static PizzaBoxDbContext Instance
    {
      get
      {
        return _dbContext;
      }
    }

    public DbSet<Size> Sizes {get; set;}
    public DbSet<Crust> Crusts { get; set; }

    //public DbSet<Pizza> Pizzas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("server=localhost;database=pizzabox;user id=sa;password=Password12345;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Pizza>().HasKey(p => p.PId);
      builder.Entity<Store>().HasKey(s => s.SId);
      builder.Entity<Order>().HasKey(o => o.OId);
      builder.Entity<User>().HasKey(u => u.UId);
      builder.Entity<Crust>().HasKey(c => c.CrustId);
      builder.Entity<Size>().HasKey(s => s.SizeId);

      builder.Entity<Crust>().HasMany(c => c.Pizzas).WithOne(p => p.crust);
      builder.Entity<Size>().HasMany(s => s.Pizzas).WithOne(p => p.size);
      builder.Entity<Order>().HasMany(o => o.Pizzas).WithOne(p => p.ord);
      builder.Entity<User>().HasMany(u => u.Orders).WithOne(o => o.usr);
      builder.Entity<Store>().HasMany(s=> s.Orders).WithOne(o=> o.str);

      builder.Entity<Crust>().HasData(new Crust[]
      {
        new Crust() {Name = "Gluten Free", Price = 5.00M, CrustId = 1},
        new Crust() { Name = "Deep Dish", Price = 3.50M, CrustId = 2 },
        new Crust() { Name = "New York Style", Price = 2.50M, CrustId = 3 },
        new Crust() { Name = "Thin Crust", Price = 1.50M, CrustId = 4 }
      });

      builder.Entity<Size>().HasData(new Size[]
      {
        new Size() { Name = "Large", Price = 12.00M, SizeId = 1 },
        new Size() { Name = "Medium", Price = 10.00M, SizeId = 2 },
        new Size() { Name = "Small", Price = 8.00M, SizeId = 3 },
      });
    }
  }
}