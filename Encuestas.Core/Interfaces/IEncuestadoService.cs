using Encuestas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuestas.Core.Interfaces
{
    public interface IEncuestadoService
    {
        Task<Encuestado> InsertarEncuestado(Encuestado encuestado);
        Task<Encuestado> ObtenerEncuestadoPorId(int id);
    }
}
