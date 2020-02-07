using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AUSATestWeb
{
    public class TicketDetail
    {
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Nombre_Estacion { get; set; }
        public float Importe { get; set; }
        public int Categoria { get; set; }
        public string Via { get; set; }
        public string Dominio { get; set; }
    }
}
