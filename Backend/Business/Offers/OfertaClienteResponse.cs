using System;
using System.Collections.Generic;

namespace Business.Offers
{
    public partial class OfertaClienteResponse
    {
        public int IdOfertaCliente { get; set; }
        public int IdNroOferta { get; set; }
        public int IdCliente { get; set; }
        public int Disponible { get; set; }
        public int ConsumIdo { get; set; }

        public NroOfertaResponse NroOferta { get; set; }
        public ClienteResponse Cliente { get; set; }
    }
}
