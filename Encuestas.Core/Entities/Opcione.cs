using System;
using System.Collections.Generic;

#nullable disable

namespace Encuestas.Core.Entities
{
    public partial class Opcione
    {
        public int Idopcion { get; set; }
        public int? Idpregunta { get; set; }
        public string Opcion { get; set; }
        public int? Orden { get; set; }

        public virtual Pregunta IdpreguntaNavigation { get; set; }
    }
}
