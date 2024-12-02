namespace GaremtalApp_Api.Models
{
	public abstract class BaseEntity
	{
		public int Id { get; set; }
		public string Durum { get; set; }         // Örnek: "Aktif"

	}
}
