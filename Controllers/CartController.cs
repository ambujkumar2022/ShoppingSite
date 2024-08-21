using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingSite.Data;
using ShoppingSite.Models;

namespace ShoppingSite.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CartController : ControllerBase
	{
		private readonly ShoppingContext _context;
		public CartController(ShoppingContext context)
		{
			_context = context;
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<Cart>> GetCart(int id)
		{
			var cart = await _context.Carts.Include(c => c.Items)
							  .ThenInclude(i => i.Shirt)
							  .FirstOrDefaultAsync(c => c.Id == id);

            if (cart == null)
            {
				return NotFound();
            }
            return cart;
		}
	}
}
