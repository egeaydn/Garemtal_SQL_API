namespace GaremtalApp_Api.Models
{
	public class Teachers : BaseEntity
	{
		//public string Ad { get; set; }
		//public string Soyad { get; set; }
		//public string Sifre { get; set; }
		//public string TelefonNo { get; set; }
		//public string OturduguIlce { get; set; }
		//public string UzmanlıkAlanıDersler { get; set; }
		//public string Cinsiyet { get; set; }

		public string Ad { get; set; }
		public string Soyad { get; set; }
		public DateTime DogumTarihi { get; set; }
		public string Email { get; set; }
		public string Sifre { get; set; }
		public string Telefon { get; set; }
		public string Adres { get; set; }
		public string Bolum { get; set; }
		public string Unvan { get; set; }
		public string Dersler { get; set; }
		public string Cinsiyet { get; set; }

	}
}
