﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenter.Models.BM
{
    public class SPClienteBM
    {
        [Key]
        public int Cedula { get; set; }
        public string Nombre_Completo { get; set; }
        public DateTime Fecha_Pago { get; set; }    
        public decimal Monto { get; set; }

    }
}
