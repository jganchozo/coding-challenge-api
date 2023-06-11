using Encuestas.Core.DTOs;
using Encuestas.Core.Entities;
using Encuestas.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encuestas.Core.Services
{
    public class ReportesService: IReportesService
    {
        private readonly IRepository<Respuesta> _respuestaRepository;
        private readonly IRepository<Pregunta> _preguntataRepository;
        private readonly IRepository<Encuesta> _encuestaRepository;

        public ReportesService(IRepository<Respuesta> respuestaRepository, IRepository<Pregunta> preguntataRepository, IRepository<Encuesta> encuestaRepository)
        {
            _respuestaRepository = respuestaRepository;
            _preguntataRepository = preguntataRepository;
            _encuestaRepository = encuestaRepository;

        }

        public async Task<int> ObtenerPorcentajePregunta(string pregunta)
        {
            List<string> propiedadesIncluir = new() { "Respuesta", "Opciones" };
            var preguntaResultados = await _preguntataRepository.GetByStringParameter("Pregunta1", pregunta, propiedadesIncluir);
            var comidaRapida = preguntaResultados.Opciones.Where(x => x.Orden > 1).ToList();

            var respuestasTotal = await _respuestaRepository.GetById(preguntaResultados.Idencuesta);



            return 2;
        }

        public async Task<IEnumerable<RespuestaReporte>> ObtenerRespuestas(string encuesta)
        {
            List<string> propiedadesIncluir = new() { "IdpreguntaNavigation" };
            List<RespuestaReporte> listaReporte = new();
            IEnumerable<Respuesta> result;

            try
            {
                var encuestas = await _encuestaRepository.GetAll();
                var idEncuesta = encuestas.Where(e => e.Titulo == encuesta).FirstOrDefault().Idencuesta;

                result = await _respuestaRepository.GetById(idEncuesta, "Idencuesta", propiedadesIncluir);

                propiedadesIncluir.Clear();
                propiedadesIncluir.Add("Opciones");

                List<PreguntasOpcionesReporteDto> reporteDos = new();

                var preguntas = await _preguntataRepository.GetById(1, propiedadesIncluir, "Idencuesta");
                var opciones = preguntas.Opciones;
                

                var grupos = result
                             .Where(respuesta => respuesta.IdpreguntaNavigation.Orden == 1)
                             .GroupBy(respuesta => new { respuesta.Codigo, respuesta.Fecha })
                             .Select(group => new
                             {
                                 GroupKey = group.Key,
                                 Count = group.Count(),
                                 Date = group.Key.Fecha,
                                 Codigos = group.Select(x => x.Codigo).ToList(),
                                 Respuestas = group.Select(p => p.Respuesta1),
                             });

                var encuestasPorDias = grupos.GroupBy(x => new { x.Date })
                                 .Select(group => new
                                 {
                                     GroupKey = group.Key,
                                     Count = group.Count(),
                                     Codigo = group.ToList().Select(c => c.Codigos.FirstOrDefault()),
                                     Respuestas = group.SelectMany(r => r.Respuestas),
                                     group.Key.Date
                                 });

                foreach (var item in encuestasPorDias)
                {

                    RespuestaReporte respuestas = new()
                    {
                        Fecha = item.Date.Value.ToString("MM-dd-yyyy"),
                        Cantidad = item.Count,
                        Reporte = new List<RespuestaCantidad>()
                    };

                    var reporte = item.Respuestas.GroupBy(encuesta => new { encuesta })
                    .Select(group => new RespuestaCantidad()
                    {
                        Respuesta = group.Key.encuesta,
                        Cantidad = group.Count(),
                    }).ToList();

                    List<string> listaRespuestas = reporte.Select(respuesta => respuesta.Respuesta).ToList();
                    List<string> validar = opciones.Select(c => c.Opcion).ToList();

                    var valoresNoCoincidentes = validar.Except(listaRespuestas).ToList();

                    foreach (var adicional in valoresNoCoincidentes)
                    {
                        RespuestaCantidad dataToAdd = new()
                        {
                            Respuesta = adicional,
                            Cantidad = 0,
                        };

                        reporte.Add(dataToAdd);

                    }

                    respuestas.Reporte = reporte.OrderBy(x => x.Respuesta).ToList();

                    listaReporte.Add(respuestas);
                }

            }
            catch (Exception)
            {

                throw;
            }

            return listaReporte;
        }

        public async Task<IEnumerable<PreguntasOpcionesReporteDto>> ObtenerRespuestasOpciones()
        {
            List<string> propiedadesIncluir = new() { "Opciones" };
            List<PreguntasOpcionesReporteDto> reporte = new();

            var preguntas = await _preguntataRepository.GetById(1, "Idencuesta", propiedadesIncluir);

            var respuestas = await _respuestaRepository.GetById(1, "Idencuesta");

            preguntas = preguntas.Where(x => x.IdtipoRespuesta == 1);

            var respuestasAgrupadas = respuestas
                .GroupBy(respuesta => new { respuesta.Respuesta1 })
                .Select(group => new
                {
                    GroupKey = group.Key,
                    Count = group.Count(),
                    Encuestados = group.Select(encuestado => encuestado.Idencuestado).GroupBy(usuarios => new { usuarios }).ToList().Count,
                });


            foreach (var item in preguntas)
            {
                PreguntasOpcionesReporteDto preguntasOpciones = new();
                preguntasOpciones.Pregunta = item.Pregunta1;
                preguntasOpciones.Opciones = new List<Opcion>();

                foreach (var opcion in item.Opciones)
                {
                    Opcion option = new()
                    {
                        Nombre = opcion.Opcion
                    };

                    var encuestados = respuestasAgrupadas.Where(r => r.GroupKey.Respuesta1 == opcion.Opcion).FirstOrDefault()?.Encuestados;
                    option.Cantidad = encuestados.HasValue ? encuestados.Value : 0;
                    preguntasOpciones.Opciones.Add(option);
                }

                reporte.Add(preguntasOpciones);

            }

            return reporte;
        }
    }
}
