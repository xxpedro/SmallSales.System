using System;
using System.Collections.Generic;

namespace Small_Sales_System.Models
{
    public partial class Usuarios
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Clave { get; set; }
        public string Correo { get; set; }
    }
}
