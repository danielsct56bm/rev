namespace domain.Entities;

public partial class servicios
{
    public int id { get; set; }

    public int? idCliente { get; set; }

    public string? servicio { get; set; }

    public DateTime? fechaInicio { get; set; }

    public DateTime? fechaRenovacion { get; set; }

    public decimal? monto { get; set; }

    public virtual clientes? idClienteNavigation { get; set; }

    public virtual ICollection<tickets> tickets { get; set; } = new List<tickets>();
}
