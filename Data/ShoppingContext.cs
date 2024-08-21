using Microsoft.EntityFrameworkCore;
using ShoppingSite.Models;

namespace ShoppingSite.Data
{
	public class ShoppingContext : DbContext
	{
		public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options) 
		{ }
		public DbSet<Shirt> Shirts { get; set; }
		public DbSet<Cart> Carts { get; set; }
		public DbSet<CartItem> CartItems { get; set; }
	}
}
