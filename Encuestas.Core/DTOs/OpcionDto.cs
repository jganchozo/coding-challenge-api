using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuestas.Core.DTOs
{
    public class OpcionDto
    {
        public int Idopcion { get; set; }
        public int? Idpregunta { get; set; }
        public string Opcion { get; set; }
        public int? Orden { get; set; }
    }
}
