namespace application;

public class ServicioDto
{
    public int id { get; set; }
    public int? idCliente { get; set; }
    public string? servicio { get; set; }
    public DateTime fechaInicio { get; set; }
    public DateTime? fechaRenovacion { get; set; }
    public decimal? monto { get; set; }
}