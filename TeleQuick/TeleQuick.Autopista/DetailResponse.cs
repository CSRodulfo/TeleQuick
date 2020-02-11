using System;
using System.Collections.Generic;
using System.Text;

namespace TeleQuick.Autopista
{
    public class DetailResponse
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
