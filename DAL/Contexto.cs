using Microsoft.EntityFrameworkCore;

namespace AP1_P1_MarcosRosario.DAL
{
	public class Contexto : DbContext
	{
		public Contexto(DbContextOptions<Contexto> options) 
			: base(options) { }

	}
}
