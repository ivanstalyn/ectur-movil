using System;
using System.Collections.Generic;
using System.Text;

namespace ecuadorTuristico.Models
{
    public class Produtcs
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Precio { get; set; }
        public string Foto { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
    }
}
