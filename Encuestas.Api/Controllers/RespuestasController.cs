using Encuestas.Core.DTOs;
using Encuestas.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Encuestas.Core.Interfaces;
using AutoMapper;

namespace Encuestas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespuestasController : ControllerBase
    {
        private readonly IRespuestasService _respuestasService;
        public RespuestasController(IRespuestasService respuestasService)
        {
            _respuestasService = respuestasService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertarRespuestas(EncuestaRespuestasDto respuestasDto)
        {
            var result = await _respuestasService.InsertarRespuesta(respuestasDto);

            return Ok(result);
        }
    }
}
