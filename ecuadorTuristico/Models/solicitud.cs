using System;
using System.Collections.Generic;
using System.Text;

namespace ecuadorTuristico.Models
{
    public class solicitud
    {
        public List<productoS> respuestaSol { set; get; }
        public string message { set; get; }
        public string mensaje { set; get; }
        public producto producto { set; get; }
        public usuario usuario { set; get; }
    }
}
