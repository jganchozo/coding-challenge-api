using Encuestas.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Encuestas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private readonly IReportesService _reportesService;
        public ReportesController(IReportesService reportesService)
        {
            _reportesService = reportesService;
        }

        [HttpGet("PrimerReporte/{encuesta}")]
        public async Task<IActionResult> ObtenerRespuestas(string encuesta)
        {
            var result = await _reportesService.ObtenerRespuestas(encuesta);

            return Ok(result);
        }

        [HttpGet("PorcentajePregunta/{encuesta}")]
        public async Task<IActionResult> ObtenerPorcentajePregunta(string encuesta)
        {
            var result = await _reportesService.ObtenerPorcentajePregunta(encuesta);

            return Ok(result);
        }

        [HttpGet("SegundoReporte")]
        public async Task<IActionResult> ObtenerRespuestasOpciones()
        {
            var result = await _reportesService.ObtenerRespuestasOpciones();

            return Ok(result);
        }
    }
}
