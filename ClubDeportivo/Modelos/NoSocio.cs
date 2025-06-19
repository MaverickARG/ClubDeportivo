using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Modelos
{
    public class NoSocio : Persona
    {
        public int IdNoSocio { get; set; }
        public DateTime FechaActividad { get; set; }
        public bool NoSocioActivo { get; set; }

       
    }
}