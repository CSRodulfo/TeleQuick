using System;
using System.Collections.Generic;

namespace Business.Offers
{
    public partial class PromocionResponse
    {

        public int IdPromocion { get; set; }
        public int IdNroOferta { get; set; }
        public int IdOfertaPromocionTUF { get; set; }
        public int Orden { get; set; }
        public string Descripcion { get; set; }
        public int IdCucarda { get; set; }
        public DateTime VigenciaDesde { get; set; }
        public DateTime VigenciaHasta { get; set; }

        public NroOfertaResponse NroOferta { get; set; }
        public CucardaResponse Cucarda { get; set; }
        public List<ArticuloPromocionResponse> ArticuloPromocion { get; set; }
    }
}
