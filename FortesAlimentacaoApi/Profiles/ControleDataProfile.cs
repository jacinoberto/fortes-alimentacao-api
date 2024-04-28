using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.ControleData;
using FortesAlimentacaoApi.Database.Models;

namespace FortesAlimentacaoApi.Profiles;

public class ControleDataProfile : Profile
{
    public ControleDataProfile()
    {
        CreateMap<InserirControleData, ControleData>();
        CreateMap<ControleData, RetornarControleData>();
    }
}
