namespace FortesAlimentacaoApi.Profiles;

using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Operario;
using FortesAlimentacaoApi.Database.Models;

public class OperarioProfile : Profile
{
    public OperarioProfile()
    {
        CreateMap<InserirOperario, Operario>();
        CreateMap<Operario, RetornarOperario>();
        CreateMap<Operario, RetornoOperarioEquipe>();
        CreateMap<Operario, RetornoOperarioRefeicao>();
        CreateMap<Operario, OperarioSelect>();
    }
}
