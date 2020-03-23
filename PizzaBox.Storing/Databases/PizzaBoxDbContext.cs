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
    public DbSet<Type> Types { get; set; }

    public DbSet<Order> Orders {get; set;}
    public DbSet<Pizza> Pizzas {get; set;}
    public DbSet<User> Users {get; set;}
    public DbSet<Store> Stores{get; set;}


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
      builder.Entity<Type>().HasKey(t => t.TypeId);

      builder.Entity<Crust>().HasMany(c => c.Pizzas).WithOne(p => p.crust);
      builder.Entity<Type>().HasMany(t => t.Pizzas).WithOne(p => p.type);
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

      builder.Entity<Type>().HasData(new Type[]
      {
        new Type() { Name = "Pepperoni", Price = 3.00M, TypeId = 1 },
        new Type() { Name = "Sausage", Price = 3.00M, TypeId = 2 },
        new Type() { Name = "Vegetable", Price = 3.00M, TypeId = 3 },
      });

      builder.Entity<User>().HasData(new User[]
      {
        new User() {username ="nick", password = "password", UId =1 },
        new User() {username ="fred", password = "password12345", UId=2  },
        new User() {username ="random", password = "passwordrandom",UId =3 },
      });

      builder.Entity<Store>().HasData(new Store[]
      {
        new Store() {location ="Domino's", username = "dominos" ,password = "dominos", SId = 1 },
        new Store() {location ="Papa John's",username = "papajohn" , password = "papajohn", SId = 2  },
        new Store() {location ="Nick's Pizza",username = "nickspizza" , password = "deepdishonly", SId = 3 },
      });
    }
  }
}