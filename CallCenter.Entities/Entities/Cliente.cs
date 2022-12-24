using CallCenter.Utilities.BaseEntity;
using System;
using System.Collections.Generic;

namespace CallCenter;

public partial class Cliente:BaseEntity
{
    public string NombreCompleto { get; set; } = null!;

    public int Cedula { get; set; }

    public int Pin { get; set; }

    public virtual ICollection<TablaPago> TablaPagos { get; } = new List<TablaPago>();
}
