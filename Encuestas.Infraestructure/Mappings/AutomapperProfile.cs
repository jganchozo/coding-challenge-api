using AutoMapper;
using Encuestas.Core.DTOs;
using Encuestas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuestas.Infraestructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Encuesta, EncuestaDto>();
            CreateMap<EncuestaDto, Encuesta>();

            CreateMap<PreguntaDto, Pregunta>();
            CreateMap<Pregunta, PreguntaDto>();

            CreateMap<OpcionDto, Opcione>();
            CreateMap<Opcione, OpcionDto>();
        }
    }
}
