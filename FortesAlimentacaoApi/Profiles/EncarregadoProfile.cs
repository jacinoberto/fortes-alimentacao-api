namespace FortesAlimentacaoApi.Profiles;

using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Encarregado;
using FortesAlimentacaoApi.Database.Models;

public class EncarregadoProfile : Profile
{
    public EncarregadoProfile()
    {
        CreateMap<InserirEncarregado, Encarregado>()
            .ForMember(encarregado => encarregado.Gestor,
            option => option.MapFrom(encarregadoDto => encarregadoDto.Gestor))
            .ReverseMap();

        CreateMap<Encarregado, RetornarEncarregado>()
            .ForMember(encarregadoDto => encarregadoDto.Gestor,
            option => option.MapFrom(encarregado => encarregado.Gestor))
            .ReverseMap();

        CreateMap<Encarregado, RetornoEncarregadoGestao>()
            .ForMember(encarregadoDto => encarregadoDto.Gestor,
            option => option.MapFrom(encarregado => encarregado.Gestor))
            .ReverseMap();

        CreateMap<Encarregado, EncarregadoSelect>()
            .ForMember(encarregadoDto => encarregadoDto.Gestor,
            option => option.MapFrom(encarregado => encarregado.Gestor))
            .ReverseMap();

        CreateMap<Encarregado, RetornoEncarregadoGestaoSelect>()
            .ForMember(encarregadoDto => encarregadoDto.Gestor,
            option => option.MapFrom(encarregado => encarregado.Gestor))
            .ReverseMap();
    }
}
