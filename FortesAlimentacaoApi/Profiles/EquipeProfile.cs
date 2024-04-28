using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Equipe;
using FortesAlimentacaoApi.Database.Models;

namespace FortesAlimentacaoApi.Profiles;

public class EquipeProfile : Profile
{
    public EquipeProfile()
    {
        CreateMap<InserirEquipe, Equipe>();

        CreateMap<Equipe, RetornarEquipe>()
            .ForMember(equipeDto => equipeDto.GestaoEquipe,
            option => option.MapFrom(equipe => equipe.GestaoEquipe))
            .ReverseMap();

        CreateMap<Equipe, RetornoEquipeRefeicao>()
            .ForMember(equipeDto => equipeDto.Operario,
            option => option.MapFrom(equipe => equipe.Operario))
            .ReverseMap();
    }
}
