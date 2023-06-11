using System;
using System.Collections.Generic;

namespace Encuestas.Core.DTOs
{
    public class EncuestaDto
    {
        public int Idencuesta { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha { get; set; }

        public ICollection<PreguntaDto> Pregunta { get; set; }
        //public ICollection<Respuesta> Respuesta { get; set; }
    }
}
