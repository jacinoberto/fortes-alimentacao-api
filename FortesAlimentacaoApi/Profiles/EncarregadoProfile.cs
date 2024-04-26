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
    }
}
