using System;
using System.Collections.Generic;

namespace CajeroAutomatico.Model;

public partial class Rol
{
    public int IdRol { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<MenuRol> MenuRols { get; set; } = new List<MenuRol>();
}
