﻿using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Obra;
using FortesAlimentacaoApi.Database.Models;

namespace FortesAlimentacaoApi.Profiles;

public class ObraProfile : Profile
{
    public ObraProfile()
    {
        CreateMap<InserirObra, Obra>()
            .ForMember(obra => obra.Endereco,
            option => option.MapFrom(obraDto => obraDto.Endereco))
            .ReverseMap();

        CreateMap<Obra, RetornarObra>()
            .ForMember(obraDto => obraDto.Endereco,
            opriton => opriton.MapFrom(obra => obra.Endereco))
            .ReverseMap();

        CreateMap<Obra, RetornoObraGestao>();

        CreateMap<Obra, RetornarObraSelect>();

        CreateMap<Obra, ObraSelectData>()
            .ForMember(obraDto => obraDto.Endereco,
            option => option.MapFrom(obra => obra.Endereco));
    }
}