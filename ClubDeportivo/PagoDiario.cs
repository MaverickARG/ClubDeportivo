using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo
{
    public class PagoDiario
    {
        public int IdPagoDiario { get; set; }
        public DateTime FechaPagoDiario { get; set; }
        public string FormaPago { get; set; }
        public int IdActividad { get; set; }
        public int NumeroPagoDiario { get; set; }
    }
}
