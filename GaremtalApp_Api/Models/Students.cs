namespace GaremtalApp_Api.Models
{
	public class Students :BaseEntity
	{
		public string Ad { get; set; }
		public string Soyad { get; set; }
		public string TcNo { get; set; }
		public int OkulNo { get; set; }
		public DateTime DogumTarihi { get; set; }
		public string Sifre { get; set; }
		public string Telefon { get; set; }
		public string Adres { get; set; }
		public string Bolum { get; set; }
		public int SinifID { get; set; }
		public DateTime KayitTarihi { get; set; }
	}
}
