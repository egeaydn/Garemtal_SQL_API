using GaremtalApp_Api.DataContext;
using GaremtalApp_Api.Models;

namespace GaremtalApp_Api.Seeder
{
	public class StudentSeeder
	{
		public static void Seed(SchoolDBcontext context)
		{
			// Veritabanında veri olup olmadığını kontrol et
			if (context.Ogrenciler.Any())
			{
				return; // Veriler zaten mevcut
			}
			var students = new List<Students>
			{
				new Students
				{
					Ad = "Ege",
					Soyad ="Aydın",
					TcNo = "55834057096",
					OkulNo = 615,
					DogumTarihi = new DateTime(2008, 9, 29),
					Sifre = "200842",
					Telefon = "05444281371",
					Adres = "İstanbul/Kadıköy/Kozyatağı/19 mayıs mah/İnönü cad.",
					Bolum = "Bilişim Teknolojileri",
					SinifID = 2,
					KayitTarihi = DateTime.Now,
					Durum = "Aktif",
				}
			};


			context.Ogrenciler.AddRange(students);
			context.SaveChanges();


		}
	}
}

