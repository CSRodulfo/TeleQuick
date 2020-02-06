using System;
using System.Collections.Generic;

namespace Business.Offers
{
    public partial class CategoriaResponse
    {
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public int Orden { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }

        public List<ArticuloResponse> Articulo { get; set; }
    }
}
