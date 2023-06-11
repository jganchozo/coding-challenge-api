using Encuestas.Core.Entities;
using Encuestas.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuestas.Core.Services
{
    public class EncuestadoService: IEncuestadoService
    {
        private readonly IRepository<Encuestado> _encuestadoRepository;
        public EncuestadoService(IRepository<Encuestado> encuestadoRepository)
        {
            _encuestadoRepository = encuestadoRepository;
        }

        public async Task<Encuestado> InsertarEncuestado(Encuestado encuestado)
        {
            await _encuestadoRepository.Add(encuestado);
            return encuestado;
        }

        public Task<Encuestado> ObtenerEncuestadoPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
