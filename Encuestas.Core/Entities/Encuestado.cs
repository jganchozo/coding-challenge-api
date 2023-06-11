using System;
using System.Collections.Generic;

#nullable disable

namespace Encuestas.Core.Entities
{
    public partial class Encuestado
    {
        public Encuestado()
        {
            Respuesta = new HashSet<Respuesta>();
        }

        public int Idencuestado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string UidUsuario { get; set; }

        public virtual ICollection<Respuesta> Respuesta { get; set; }
    }
}
