using System;
using System.Collections.Generic;

namespace Business.Offers
{
    public partial class NroOfertaResponse
    {
        public int IdNroOferta { get; set; }
        public string Descripcion { get; set; }
        public DateTime UltimaModificacion { get; set; }
    }
}
