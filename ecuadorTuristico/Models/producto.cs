using System;
using System.Collections.Generic;
using System.Text;

namespace ecuadorTuristico.Models
{
    public class producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string precio { get; set; }
        public string foto { get; set; }
        public string fechaInicioEvento { get; set; }
        public string fechaFinalEvento { get; set; }
    }
}
