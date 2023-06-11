using Encuestas.Core.DTOs;
using Encuestas.Core.Entities;
using Encuestas.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuestas.Core.Services
{
    public class RespuestasService : IRespuestasService
    {
        private readonly IRepository<Respuesta> _respuestaRepository;
        private readonly IRepository<Encuestado> _encuestadoRepository;
        public RespuestasService(IRepository<Respuesta> respuestaRepository, IRepository<Encuestado> encuestadoRepository)
        {
            _respuestaRepository = respuestaRepository;
            _encuestadoRepository = encuestadoRepository;
        }

        public Task ActualizarRespuesta(Respuesta respuesta)
        {
            throw new NotImplementedException();
        }

        public Task EliminarRespuesta(Respuesta respuesta)
        {
            throw new NotImplementedException();
        }

        public Task InsertarRespuesta(Respuesta respuesta)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertarRespuesta(EncuestaRespuestasDto respuesta)
        {
            List<Respuesta> respuestas = new();
            Guid codigoEncuesta = Guid.NewGuid();

            var encuestado = await _encuestadoRepository.GetByStringParameter("UidUsuario", respuesta.UidUsuario);
            if (encuestado is null)
            {
                encuestado = await _encuestadoRepository.Add(new Encuestado() { Apellido = "", Email = "", Nombre = "", UidUsuario = respuesta.UidUsuario });
            }

            respuesta.Idencuestado = encuestado.Idencuestado;


            try
            {
                foreach (PreguntaOpcion item in respuesta.Respuestas)
                {
                    var newRespuesta = new Respuesta()
                    {
                        Codigo = codigoEncuesta,
                        Idencuesta = respuesta.Idencuesta,
                        Idpregunta = item.Idpregunta,
                        Respuesta1 = item.Respuesta,
                        Fecha = DateTime.Now,
                        Idencuestado = respuesta.Idencuestado
                    };

                    respuestas.Add(newRespuesta);
                }

                await _respuestaRepository.AddRange(respuestas);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return true;
        }
    }
}
