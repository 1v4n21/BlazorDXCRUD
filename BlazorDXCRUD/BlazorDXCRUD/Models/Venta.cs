namespace BlazorDXCRUD.Models
{
	public class Venta
	{
		public int Id { get; set; }
		public string comprador { get; set; }
		public string articulo { get; set; }
		public int cantidad { get; set; }
		public int precio { get; set; }
		public DateTime Date { get; set; } = DateTime.Now;
	}
}
