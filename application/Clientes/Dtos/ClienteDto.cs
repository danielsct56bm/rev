namespace application.Clientes.Dtos;

public class ClienteDto
{
    public int id { get; set; }
    public string? nombre { get; set; }
    public string? correo { get; set; }
    public DateTime? fechaRegistro { get; set; }
}