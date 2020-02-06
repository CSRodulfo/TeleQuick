using System;
using System.Collections.Generic;

namespace Business.Offers
{
    public partial class ArticuloResponse
    {
        public int IdArticulo { get; set; }
        public int CUF { get; set; }
        public string Descripcion { get; set; }
        public double PrecioPublico { get; set; }
        public double PrecioOferta { get; set; }
        public int IdCategoria { get; set; }
        public int IdMarca { get; set; }

        //public List<ArticuloPromocionDto> ArticuloPromocion { get; set; }
    }
}
