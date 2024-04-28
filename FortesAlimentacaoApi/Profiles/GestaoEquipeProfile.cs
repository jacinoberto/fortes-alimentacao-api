using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.GestaoEquipe;
using FortesAlimentacaoApi.Database.Models;

namespace FortesAlimentacaoApi.Profiles;

public class GestaoEquipeProfile : Profile
{
    public GestaoEquipeProfile()
    {
        CreateMap<InserirGestaoEquipe, GestaoEquipe>();
        
        CreateMap<GestaoEquipe, RetornarGestaoEquipe>()
            .ForMember(gestaoDto => gestaoDto.Obra,
            option => option.MapFrom(gestao => gestao.Obra))
            .ReverseMap()
            .ForMember(gestao => gestao.Encarregado,
            option => option.MapFrom(gestaoDeto => gestaoDeto.Encarregado));
    }
}
