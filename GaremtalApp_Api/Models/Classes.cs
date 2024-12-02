namespace GaremtalApp_Api.Models
{
	public class Classes : BaseEntity
	{
		public class Classroom
		{
			//public string SınıfAdı { get; set; }
			//public int Mevcut { get; set; }
			//public int OgretmenID { get; set; }

			public string Adı { get; set; }           // Örnek: "10-A"
			public string Kat { get; set; }           // Örnek: "2. Kat"
			public string Bölüm { get; set; }         // Örnek: "Fen Bölümü"
			public int Kapasite { get; set; }         // Örnek: 30
			public int MevcutOgrenciSayisi { get; set; } // Örnek: 25
			public string SınıfSeviyesi { get; set; } // Örnek: "9. Sınıf"
			public string OgretmenID { get; set; } // Örnek: "Ahmet Yılmaz"
			public List<string> DersProgramı { get; set; } // Örnek: ["Matematik", "Fizik"]
			public bool AkıllıTahtaVarMı { get; set; } // Örnek: true
			public bool ProjeörVarMı { get; set; }    // Örnek: false
		}

	}
}
