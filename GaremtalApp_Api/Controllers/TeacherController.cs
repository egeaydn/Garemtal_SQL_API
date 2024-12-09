using Microsoft.AspNetCore.Mvc;
using GaremtalApp_Api.DataContext;
using GaremtalApp_Api.Models;
using Microsoft.EntityFrameworkCore;


namespace GaremtalApp_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TeacherController : ControllerBase
	{
		private readonly SchoolDBcontext _context;
		public TeacherController(SchoolDBcontext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Teachers>>> GetTeachers()
		{
			if (_context.Ogretmenler.Count() > 0)
			{
				return await _context.Ogretmenler.ToListAsync();
			}

			return NotFound();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Teachers>> GetTeachers(int id)
		{
			var teachers = await _context.Ogretmenler.FindAsync(id);

			if (teachers == null)
			{
				return NotFound();
			}

			return teachers;

		}

		[HttpPost]
		public async Task<ActionResult<Teachers>> PostTeachers(Teachers teachers)
		{
			_context.Ogretmenler.Add(teachers);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetTeachers), new { id = teachers.Id }, teachers);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutTeachers(int id, Teachers teachers)
		{
			if (id != teachers.Id)
			{
				return NoContent();
			}

			_context.Entry(teachers).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!TeacherExists(id))
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
			var teachers = await _context.Ogretmenler.FindAsync(id);
			if (teachers == null)
			{
				return NotFound();
			}

			_context.Ogretmenler.Remove(teachers);
			await _context.SaveChangesAsync();

			return Ok();
		}

		private bool TeacherExists(int id)
		{
			return _context.Ogretmenler.Any(p => p.Id == id);
		}

	}
}
