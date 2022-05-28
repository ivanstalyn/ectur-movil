using System;
using System.Collections.Generic;
using System.Text;

namespace ecuadorTuristico.Models
{
    public class usuario
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string identificacion { get; set; }
        public string telefono { get; set; }
        public string fechaNacimiento { get; set; }
        public genero genero { get; set; }
        public rol rol { get; set; }
        public empresa empresa { get; set; }
    }
}
