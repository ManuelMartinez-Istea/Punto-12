using System;
using System.Collections.Generic;

namespace Punto_12.Models
{
    public partial class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? FechaNacimiento { get; set; }
    }
}
