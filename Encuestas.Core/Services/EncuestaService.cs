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
    public class EncuestaService: IEncuestaService
    {
        private readonly IRepository<Encuesta> _encuestaRepository;
        private readonly IRepository<Pregunta> _preguntaRepository;
        private readonly IRepository<Opcione> _opcionRepository;
        public EncuestaService(IRepository<Encuesta> encuestaRepository, 
                               IRepository<Pregunta> preguntaRepository, 
                               IRepository<Opcione> opcionRepository)
        {
            _encuestaRepository = encuestaRepository;
            _preguntaRepository = preguntaRepository;
            _opcionRepository  = opcionRepository;
        }

        public async Task<bool> EliminarEncuesta(int id)
        {
            bool result = false;

            try
            {
                List<string> propiedadesIncluir = new() { "Pregunta", "Respuesta", "Pregunta.Opciones" };
                var preguntas = await _encuestaRepository.GetById(id, propiedadesIncluir, "Idencuesta");
                //var all = await _encuestaRepository.GetAll(propiedadesIncluir);

                if (preguntas is not null && preguntas.Respuesta.Count <= 0)
                {
                    if (preguntas.Pregunta is not null && preguntas.Pregunta.Count > 0 && preguntas.Pregunta.First().Opciones.Count > 0)
                        await _opcionRepository.DeleteRange(preguntas.Pregunta.ToList().SelectMany(x => x.Opciones).ToList());

                    if (preguntas.Pregunta is not null && preguntas.Pregunta.Count > 0)
                        await _preguntaRepository.DeleteRange(preguntas.Pregunta);

                    await _encuestaRepository.Delete(preguntas);

                    result = true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return result;
        }

        public async Task<IEnumerable<Encuesta>> ObtenerEncuestas()
        {
            var encuestas = await _encuestaRepository.GetAll();

            return encuestas;
        }

        public async Task<Encuesta> ObtenerEncuestaById(int id)
        {
            List<string> propiedadesIncluir = new() { "Pregunta", "Pregunta.Opciones" };
            var encuesta = await _encuestaRepository.GetById(id, propiedadesIncluir, "Idencuesta");

            return encuesta;
        }

        public async Task<Encuesta> CrearEncuesta(Encuesta encuesta)
        {
            var result = await _encuestaRepository.Add(encuesta);

            return result;
        }

        public async Task<Encuesta> ActualizarEncuesta(Encuesta encuesta)
        {
            List<string> propiedadesIncluir = new() { "Pregunta", "Pregunta.Opciones" };
            var encuestaResult = await _encuestaRepository.GetById(encuesta.Idencuesta, propiedadesIncluir, "Idencuesta");
            encuestaResult.Titulo = encuesta.Titulo;
            encuestaResult.Descripcion = encuesta.Descripcion;
            encuestaResult.Pregunta = encuesta.Pregunta;
            await _encuestaRepository.Update(encuestaResult);

            return encuestaResult;
        }
    }
}
