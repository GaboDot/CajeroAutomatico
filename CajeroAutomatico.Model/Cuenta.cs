using System;
using System.Collections.Generic;

namespace CajeroAutomatico.Model;

public partial class Cuenta
{
    public int IdCuenta { get; set; }

    public DateTime FechaCreacion { get; set; }

    public decimal Saldo { get; set; }

    public int IdCliente { get; set; }

    public int IdTarjeta { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual TarjetaCliente IdTarjetaNavigation { get; set; } = null!;

    public virtual ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
}
