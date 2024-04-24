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
			_context = context;
		}

		//Metdo para borrar ventas
		public async Task<bool> DeleteVenta(int id)
		{
			var venta = await _context.Ventas.FindAsync(id);

			_context.Ventas.Remove(venta);

			return await _context.SaveChangesAsync() > 0;
		}

		//Metodo para obtener todas las ventas
		public async Task<IEnumerable<Venta>> GetAllVentas()
		{
			return await _context.Ventas.ToListAsync();
		}

		// Método para obtener todas las ventas de un artículo específico
		public async Task<IEnumerable<Venta>> GetVentasByArticulo(string nombreArticulo)
		{
			return await _context.Ventas
				.Where(v => v.articulo == nombreArticulo)
				.ToListAsync();
		}

		//Metodo para obtener venta por id
		public async Task<Venta> GetVentaDetails(int id)
		{
			return await _context.Ventas.FindAsync(id);
		}

		//Metodo para insertar venta
		public async Task<bool> InsertVenta(Venta venta)
		{
			_context.Ventas.Add(venta);

			return await _context.SaveChangesAsync() > 0;
		}

		//Metodo intermediario para saber si es un insert o update
		public async Task<bool> SaveVenta(Venta venta)
		{
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
			_context.Entry(venta).State = EntityState.Modified;

			return await _context.SaveChangesAsync() > 0;
		}
	}
}
