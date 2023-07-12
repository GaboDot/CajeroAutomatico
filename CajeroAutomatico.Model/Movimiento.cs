using System;
using System.Collections.Generic;

namespace CajeroAutomatico.Model;

public partial class Movimiento
{
    public int IdMovimiento { get; set; }

    public DateTime FechaMovimiento { get; set; }

    public int Accion { get; set; }

    public decimal Cantidad { get; set; }

    public int IdCuenta { get; set; }

    public virtual Cuenta IdCuentaNavigation { get; set; } = null!;
}
