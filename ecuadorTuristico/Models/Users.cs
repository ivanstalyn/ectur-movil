using System;
using System.Collections.Generic;
using System.Text;

namespace ecuadorTuristico.Models
{
    public class Users
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string FechaNacimiento { get; set; }
        public int Genero { get; set; }

    }
}
