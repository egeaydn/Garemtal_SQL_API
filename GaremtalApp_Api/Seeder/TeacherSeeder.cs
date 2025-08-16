using GaremtalApp_Api.DataContext;
using GaremtalApp_Api.Models;

namespace GaremtalApp_Api.Seeder
{
	public class TeacherSeeder
	{
		public static void Seed(SchoolDBcontext context)
		{
			if (context.Ogretmenler.Any())
			{
				return; // veriler zaten varsa ekleme
			}

			var teachers = new List<Teachers>
			{
				new Teachers
				{
					Ad = "Engin",
					Soyad = "Keklik",
					DogumTarihi = new DateTime(1991,4,23),
					Email ="enginkeklik@gmail.com",
					Sifre ="190303",
					Telefon = "05468845672",
					Adres = "İstanbul/Üsküdar/Koşuyolu Mah.",
					Bolum = "Sayısal",
					Unvan = "Biyoloji Öğretmeni",
					Dersler = "Biyoloji-Sağlık Bilgisi",
					Cinsiyet = "Erkek",
					Durum ="Aktif"
				}
			};

			context.Ogretmenler.AddRange(teachers);
			context.SaveChanges();
		}
	}
}
