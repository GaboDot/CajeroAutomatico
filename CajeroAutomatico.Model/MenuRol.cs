using System;
using System.Collections.Generic;

namespace CajeroAutomatico.Model;

public partial class MenuRol
{
    public int IdMenuRol { get; set; }

    public int IdMenu { get; set; }

    public int IdRol { get; set; }

    public virtual Menu IdMenuNavigation { get; set; } = null!;

    public virtual Rol IdRolNavigation { get; set; } = null!;
}
