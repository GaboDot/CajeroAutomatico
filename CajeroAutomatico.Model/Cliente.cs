using System;
using System.Collections.Generic;

namespace CajeroAutomatico.Model;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string ApellidoMaterno { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public int IdRol { get; set; }

    public virtual ICollection<Cuenta> Cuenta { get; set; } = new List<Cuenta>();

    public virtual Rol IdRolNavigation { get; set; } = null!;
}
