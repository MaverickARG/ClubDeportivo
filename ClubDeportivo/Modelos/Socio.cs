using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Modelos
{
    public class Socio : Persona
    {
        public int IdSocio { get; set; }
        public DateTime FechaAltaSocio { get; set; }
        public bool CarnetActivo { get; set; }
        public double ValorCuota { get; set; }


    }
}
