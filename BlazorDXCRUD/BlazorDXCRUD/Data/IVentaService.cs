using BlazorDXCRUD.Models;
using BlazorDXCRUD.Models1;

namespace BlazorDXCRUD.Data
{
	//Interfaz parael servicio de las ventas

	public interface IVentaService
	{
		//Metodo de la interfaz para obtener todas las ventas
		Task<IEnumerable<Venta>> GetAllVentas();

		//Metodo de la interfaz para obtener una venta en concreto
		Task<Venta> GetVentaDetails(int id);

		//Metodo de la interfaz para obtener todas las ventas de un articulo en concreto
		Task<IEnumerable<Venta>> GetVentasByArticulo(string nombreArticulo);

		//Metodo de la interfaz para insertar una venta
		Task<bool> InsertVenta(Venta venta);

		//Metodo de la interfaz para actualizar una venta
		Task<bool> UpdateVenta(Venta venta);

		//Metodo de la interfaz para eliminar una venta
		Task<bool> DeleteVenta(int id);

		//Metodo de la interfaz para decidir si la venta es nueva o actualizada
		Task<bool> SaveVenta(Venta venta);
	}
}
