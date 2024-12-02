using GaremtalApp_Api.DataContext;
using GaremtalApp_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GaremtalApp_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		private readonly SchoolDBcontext _context;
		public StudentsController(SchoolDBcontext context)
		{
			_context = context;
		}

		// Get : api/Products
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Students>>> GetProducts()
		{
			if (_context.Ogrenciler.Count() > 0)
			{
				return await _context.Ogrenciler.ToListAsync();
			}

			return NotFound();
		}

		// Get : api/Products/2
		[HttpGet("{id}")]
		public async Task<ActionResult<Students>> GetProduct(int id)
		{
			var product = await _context.Ogrenciler.FindAsync(id);

			if (product == null)
			{
				return NotFound();
			}

			return product;

		}

		// POST
		[HttpPost]
		public async Task<ActionResult<Students>> PostProduct(Students students)
		{
			_context.Ogrenciler.Add(students);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetProduct), new { id = students.Id }, students);
		}
	}
}
