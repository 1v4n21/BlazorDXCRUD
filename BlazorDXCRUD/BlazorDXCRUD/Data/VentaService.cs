using BlazorDXCRUD.Models;
using BlazorDXCRUD.Models1;
using Microsoft.EntityFrameworkCore;

namespace BlazorDXCRUD.Data
{
	public class VentaService : IVentaService
	{
		//Context es la base de datos
		private readonly CreadorTablas _context;

		//Introducimos en context la base de datos
		public VentaService(CreadorTablas context)
		{
			//Obtenemos la base de datos
			_context = context;
		}

		//Metdo para borrar ventas
		public async Task<bool> DeleteVenta(int id)
		{
			//Obtenemos la venta mediante su id
			var venta = await _context.Ventas.FindAsync(id);

			//Eliminamos la venta de la BD
			_context.Ventas.Remove(venta);

			//Returnamos el resultado al eliminar la venta
			return await _context.SaveChangesAsync() > 0;
		}

		//Metodo para obtener todas las ventas
		public async Task<IEnumerable<Venta>> GetAllVentas()
		{
			//Returnamos una lista con todas las Ventas
			return await _context.Ventas.ToListAsync();
		}

		// Método para obtener todas las ventas de un artículo específico
		public async Task<IEnumerable<Venta>> GetVentasByArticulo(string nombreArticulo)
		{
			//Returnamos una lista con todas las ventas del articulo pasado por parametro
			return await _context.Ventas
				.Where(v => v.articulo == nombreArticulo)
				.ToListAsync();
		}

		//Metodo para obtener venta por id
		public async Task<Venta> GetVentaDetails(int id)
		{
			//Returnamos la venta obtenida por su id
			return await _context.Ventas.FindAsync(id);
		}

		//Metodo para insertar venta
		public async Task<bool> InsertVenta(Venta venta)
		{
			//Añadimos a la BD la venta pasada por parametro
			_context.Ventas.Add(venta);

			//Returnamos el valor obtenido al añadir una venta, sera 1 (1 fila afectada)
			return await _context.SaveChangesAsync() > 0;
		}

		//Metodo intermediario para saber si es un insert o update
		public async Task<bool> SaveVenta(Venta venta)
		{
			//Si el id de la venta no es cero es un UPDATE si es 0 es nueva (INSERT)
			if(venta.Id > 0)

			{
				return await UpdateVenta(venta);
			}

			else
			{
				return await InsertVenta(venta);
			}
		}

		//Metodo para actualizar venta
		public async Task<bool> UpdateVenta(Venta venta)
		{
			//Hacemos un UPDATE con la venta pasada por parametro
			_context.Entry(venta).State = EntityState.Modified;

			//Devolvemos el resultado al hacer UPDATE, debe de ser 1 (1 fila afectada)
			return await _context.SaveChangesAsync() > 0;
		}
	}
}
