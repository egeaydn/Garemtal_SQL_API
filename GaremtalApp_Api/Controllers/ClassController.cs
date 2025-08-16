using GaremtalApp_Api.DataContext;
using GaremtalApp_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GaremtalApp_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClassController : ControllerBase
	{
		private readonly SchoolDBcontext _context;
		public ClassController(SchoolDBcontext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Classes>>> GetTeachers()
		{
			if (_context.Ogretmenler.Count() > 0)
			{
				return await _context.Sınıflar.ToListAsync();
			}

			return NotFound();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Classes>> GetTeachers(int id)
		{
			var clases = await _context.Sınıflar.FindAsync(id);

			if (clases == null)
			{
				return NotFound();
			}

			return clases;

		}

		[HttpPost]
		public async Task<ActionResult<Classes>> PostTeachers(Classes clases)
		{
			_context.Sınıflar.Add(clases);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetTeachers), new { id = clases.Id }, clases);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutTeachers(int id, Classes clases)
		{
			if (id != clases.Id)
			{
				return NoContent();
			}

			_context.Entry(clases).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ClasesExists(id))
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

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteTerachers(int id)
		{
			var clases = await _context.Sınıflar.FindAsync(id);
			if (clases == null)
			{
				return NotFound();
			}

			_context.Sınıflar.Remove(clases);
			await _context.SaveChangesAsync();

			return Ok();
		}

		private bool ClasesExists(int id)
		{
			return _context.Sınıflar.Any(p => p.Id == id);
		}
	}
}
