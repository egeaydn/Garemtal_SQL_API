using Microsoft.EntityFrameworkCore;
using GaremtalApp_Api.Models;

namespace GaremtalApp_Api.DataContext
{
	public class SchoolDBcontext : DbContext
	{
		public SchoolDBcontext(DbContextOptions<SchoolDBcontext> options) : base(options)
		{
			
		}
		public DbSet<Classes> Sınıflar { get; set; }
		public DbSet<Students> Ogrenciler { get; set; }
		public DbSet<Teachers> Ogretmenler { get; set; }
	}
}
