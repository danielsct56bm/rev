namespace domain.Entities;

public partial class tickets
{
    public int id { get; set; }

    public int? idCliente { get; set; }

    public string ticket { get; set; } = null!;

    public string? asunto { get; set; }

    public DateTime? fechaInicio { get; set; }

    public string? status { get; set; }

    public int? idServicio { get; set; }

    public DateTime? fechaFin { get; set; }

    public string? statusFinal { get; set; }

    public virtual clientes? idClienteNavigation { get; set; }

    public virtual servicios? idServicioNavigation { get; set; }
}
