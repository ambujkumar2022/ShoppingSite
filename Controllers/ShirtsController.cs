using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingSite.Data;
using ShoppingSite.Models;

namespace ShoppingSite.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShirtsController : ControllerBase
	{
		private readonly ShoppingContext _context;

		public ShirtsController(ShoppingContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Shirt>>> GetShirts(string color, string size, string brand)
		{
			var query = _context.Shirts.AsQueryable();

			if (!string.IsNullOrEmpty(color))
			{
				query = query.Where(s => s.Color == color);
			}

			if (!string.IsNullOrEmpty(size))
			{
				query = query.Where(s => s.Size == size);
			}

			if (!string.IsNullOrEmpty(brand))
			{
				query = query.Where(s => s.Brand == brand);
			}

			return await query.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Shirt>> GetShirt(int id)
		{
			var shirt = await _context.Shirts.FindAsync(id);

			if (shirt == null)
			{
				return NotFound();
			}

			return shirt;
		}
	}

}
