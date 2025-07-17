namespace domain.Entities;

public partial class clientes
{
    public int id { get; set; }

    public string? nombre { get; set; }

    public string? correo { get; set; }

    public DateTime? fechaRegistro { get; set; }

    public virtual ICollection<servicios> servicios { get; set; } = new List<servicios>();

    public virtual ICollection<tickets> tickets { get; set; } = new List<tickets>();
}
