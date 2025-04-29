using AutoMapper;
using Odontoprev.Application.DTOs;
using Odontoprev.Domain.Entities;

namespace Odontoprev.Application.Mapping;

public class DomainToDtoProfile : Profile
{
    public DomainToDtoProfile()
    {
        CreateMap<PacienteOp, PacienteDto>().ReverseMap();
        CreateMap<ProfissionalOp, ProfissionalDto>().ReverseMap();
        CreateMap<ConsultaOp, ConsultaDto>().ReverseMap();
        CreateMap<ProcedimentoOp, ProcedimentoDto>().ReverseMap();
        CreateMap<FaturamentoOp, FaturamentoDto>().ReverseMap();
    }
}