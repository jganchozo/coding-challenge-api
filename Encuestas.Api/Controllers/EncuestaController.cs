using AutoMapper;
using Encuestas.Core.DTOs;
using Encuestas.Core.Entities;
using Encuestas.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encuestas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncuestaController : ControllerBase
    {
        private readonly IEncuestaService _encuestaService;
        private readonly IMapper _mapper;
        public EncuestaController(IEncuestaService encuestaService, IMapper mapper)
        {
            _encuestaService = encuestaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetEncuestas()
        {
            var encuestas = await _encuestaService.ObtenerEncuestas();
            var encuestaDto = _mapper.Map<IEnumerable<EncuestaDto>>(encuestas);

            return Ok(encuestaDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarEncuesta(int id)
        {
            await _encuestaService.EliminarEncuesta(id);
            return Ok(true);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPreguntasByEncuestaId(int id)
        {
            var encuesta = await _encuestaService.ObtenerEncuestaById(id);
            var encuestaQuestions = _mapper.Map<EncuestaDto>(encuesta);
            var encuestaResult = _mapper.Map<IEnumerable<PreguntaDto>>(encuesta.Pregunta);
            encuestaResult = encuestaResult.OrderBy(x => x.Orden);

            foreach (var item in encuestaResult)
            {
                item.Encuesta = encuesta.Titulo;
            }

            return Ok(encuestaResult);
        }

        [HttpPost]
        public async Task<IActionResult> CrearEncuesta(EncuestaDto encuesta)
        {
            var encuestaResult = _mapper.Map<Encuesta>(encuesta);
            var result = await _encuestaService.CrearEncuesta(encuestaResult);

            return Ok(result);
        }

        [HttpPut()]
        public async Task<IActionResult> ActualizarEncuesta(EncuestaDto encuesta)
        {
            var encuestaResult = _mapper.Map<Encuesta>(encuesta);
            var result = await _encuestaService.ActualizarEncuesta(encuestaResult);

            return Ok(result);
        }

    }
}
