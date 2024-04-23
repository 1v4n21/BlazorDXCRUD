using BlazorDXCRUD.Models;
using BlazorDXCRUD.Models1;

namespace BlazorDXCRUD.Data
{
	public interface IVentaService
	{
		Task<IEnumerable<Venta>> GetAllVentas();
		Task<Venta> GetVentaDetails(int id);
		Task<bool> InsertVenta(Venta venta);
		Task<bool> UpdateVenta(Venta venta);
		Task<bool> DeleteVenta(int id);
		Task<bool> SaveVenta(Venta venta);
	}
}
