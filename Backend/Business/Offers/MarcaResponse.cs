using System;
using System.Collections.Generic;

namespace Business.Offers
{
    public partial class MarcaResponse
    {
        public MarcaResponse()
        {
            this.Articulo = new List<ArticuloResponse>();
        }

        public int IdMarca { get; set; }
        public string Descripcion { get; set; }
        public DateTime UltimaModificacion { get; set; }

        public List<ArticuloResponse> Articulo { get; set; }
    }
}
