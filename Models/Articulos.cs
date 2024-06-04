using System.ComponentModel.DataAnnotations;

namespace AP1_P1_MarcosRosario.Models;

public class Articulos
{
	//ArticuloId, Descripcion, Costo, Ganancia y Precio.
	[Key]
	public int ArticuloId { get; set; }
	[RegularExpression(@"^[a-zA-Z\s]+$",ErrorMessage = "Caracteres Incorrectos.")]
	[Required(ErrorMessage = "Campo Obligatorio.")]
	public string? Descripcion { get; set; }
	[Range(1,float.MaxValue,ErrorMessage = "El valor del costo no puede ser menor o igual a 0.")]
	[Required(ErrorMessage = "Campo Obligatorio.")]
	public decimal Costo { get; set; }
	[Range(1, 100, ErrorMessage = "La ganancia debe de ser entre 1 a 100.")]
	[Required(ErrorMessage = "Campo Obligatorio.")]
	public decimal Ganancia { get; set; }
	[Range(1, float.MaxValue, ErrorMessage = "El valor del precio no puede ser menor o igual a 0.")]
	[Required(ErrorMessage = "Campo Obligatorio.")]
	public decimal Precio { get; set; }
}

