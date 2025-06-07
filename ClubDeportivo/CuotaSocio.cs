using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace ClubDeportivo
{
    public class CuotaSocio
    {
        public int IdCuotaSocio { get; set; }
        public DateTime FechaPagoSocio { get; set; }
        public DateTime VencimientoPago { get; set; }
        public string FormaPago { get; set; }
        public int NumeroCuota { get; set; }
    }
}
