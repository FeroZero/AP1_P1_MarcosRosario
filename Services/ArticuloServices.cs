using AP1_P1_MarcosRosario.DAL;
using AP1_P1_MarcosRosario.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AP1_P1_MarcosRosario.Services;

public class ArticuloServices
{
	private readonly Contexto _contexto;

	public ArticuloServices(Contexto contexto)
	{
		_contexto = contexto;
	}

	public async Task<decimal> Elprecio(Articulos articulos)
	{
		decimal precio = articulos.Costo * (articulos.Ganancia / 100) + articulos.Costo;
		articulos.Precio = precio;
		return articulos.Precio;
	}
	private async Task<bool> Existe(int id)
	{
		return await _contexto.Articulos
			.AnyAsync(a => a.ArticuloId == id);
	}

	private async Task<bool> Insertar(Articulos articulos)
	{
		_contexto.Articulos.Add(articulos);
		return await _contexto.SaveChangesAsync() > 0;
	}

	private async Task<bool> Modificar(Articulos articulos)
	{
		_contexto.Articulos.Update(articulos);
		return await _contexto.SaveChangesAsync() > 0;
	}

	public async Task<bool> Guardar(Articulos articulos)
	{
		if(!await Existe(articulos.ArticuloId))
			return await Insertar(articulos);
		else
			return await Modificar(articulos);
	}

	public async Task<bool> Eliminar(int id)
	{
		var articulos = await _contexto.Articulos
			.Where(a => a.ArticuloId == id).ExecuteDeleteAsync();
		return articulos > 0;
	}

	public async Task<List<Articulos>> Listar(Expression<Func<Articulos, bool>> criterio)
	{
		return await _contexto.Articulos
			.AsNoTracking()
			.Where(criterio)
			.ToListAsync();
	}
}


