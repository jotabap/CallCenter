
using System;
using System.Collections.Generic;

namespace CallCenter.Entities.Entities
{
    public partial class TablaPago : BaseEntity
    {
        public int IdPagos { get; set; }

        public int Cedula { get; set; }

        public DateTime FechaPago { get; set; }

        public decimal Monto { get; set; }

        public virtual Cliente CedulaNavigation { get; set; } = null!;
    }
}