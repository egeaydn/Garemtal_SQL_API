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
			var students = await _context.Ogrenciler.FindAsync(id);

			if (students == null)
			{
				return NotFound();
			}

			return students;

		}

		// POST
		[HttpPost]
		public async Task<ActionResult<Students>> PostProduct(Students students)
		{
			_context.Ogrenciler.Add(students);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetProduct), new { id = students.Id }, students);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutProduct(int id, Students students)
		{
			if (id != students.Id)
			{
				return NoContent();
			}

			_context.Entry(students).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ProductExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;

				}

			}

			return Ok();

		}


		// Delete : api/Products/DeleteProduct/id

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			var students = await _context.Ogrenciler.FindAsync(id);
			if (students == null)
			{
				return NotFound();
			}

			_context.Ogrenciler.Remove(students);
			await _context.SaveChangesAsync();

			return Ok();
		}

		private bool ProductExists(int id)
		{
			return _context.Ogrenciler.Any(p => p.Id == id);
		}
	}
}
