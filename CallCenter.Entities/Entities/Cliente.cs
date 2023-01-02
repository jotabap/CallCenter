
using System;
using System.Collections.Generic;

namespace CallCenter.Entities.Entities

{ 
public partial class Cliente:BaseEntity
{
    public string NombreCompleto { get; set; } = null!;

    public int Cedula { get; set; }

    public int Pin { get; set; }

    public virtual ICollection<TablaPago> TablaPagos { get; } = new List<TablaPago>();
}

}