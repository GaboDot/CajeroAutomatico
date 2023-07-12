using System;
using System.Collections.Generic;

namespace CajeroAutomatico.Model;

public partial class TarjetaCliente
{
    public int IdTarjeta { get; set; }

    public string NumeroTarjeta { get; set; } = null!;

    public DateTime FechaExpedicion { get; set; }

    public DateTime FechaExpiracion { get; set; }

    public string Nip { get; set; } = null!;

    public int IdCuenta { get; set; }

    public virtual ICollection<Cuenta> Cuenta { get; set; } = new List<Cuenta>();
}
