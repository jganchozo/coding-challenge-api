using Encuestas.Core.DTOs;
using Encuestas.Core.Entities;
using Encuestas.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuestas.Core.Interfaces
{
    public interface IPreguntaService
    {
        Task<List<PreguntaDto>> GetPreguntasByEncuestaId(int id);
    }
}
