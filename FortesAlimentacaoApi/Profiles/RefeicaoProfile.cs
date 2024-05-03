using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Refeicao;
using FortesAlimentacaoApi.Database.Models;

namespace FortesAlimentacaoApi.Profiles;

public class RefeicaoProfile : Profile
{
    public RefeicaoProfile()
    {
        CreateMap<InserirRefeicao, Refeicao>();

        CreateMap<Refeicao, RetornarRefeicao>()
            .ForMember(refeicaoDto => refeicaoDto.Equipe,
            option => option.MapFrom(refeicao => refeicao.Equipe))
            .ReverseMap()
            .ForMember(refeicao => refeicao.ControleData,
            option => option.MapFrom(refeicaoDto => refeicaoDto.ControleData));
    }
}
