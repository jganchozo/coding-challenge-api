using Encuestas.Core.DTOs;
using Encuestas.Core.Entities;
using Encuestas.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuestas.Core.Services
{
    public class PreguntaService : IPreguntaService
    {
        private readonly IRepository<Encuesta> _encuestaRepository;
        public PreguntaService(IRepository<Encuesta> encuestaRepository)
        {
            _encuestaRepository = encuestaRepository;

        }

        public Task<List<PreguntaDto>> GetPreguntasByEncuestaId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
