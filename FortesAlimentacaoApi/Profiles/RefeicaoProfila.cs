using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Refeicao;
using FortesAlimentacaoApi.Database.Models;

namespace FortesAlimentacaoApi.Profiles;

public class RefeicaoProfila : Profile
{
    public RefeicaoProfila()
    {
        CreateMap<InserirRefeicao, Refeicao>();

        CreateMap<Refeicao, RetornarRefeicao>()
            .ForMember(refeicaoDto => refeicaoDto.Equipe,
            option => option.MapFrom(refeicao => refeicao.Equipe))
            .ReverseMap();
    }
}
