using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.DataObra;
using FortesAlimentacaoApi.Database.Models;

namespace FortesAlimentacaoApi.Profiles;

public class DataObraProfile : Profile
{
    public DataObraProfile()
    {
        CreateMap<InserirDataObra, DataObra>();

        CreateMap<DataObra, RetornoDataObra>()
            .ForMember(dataDto => dataDto.Obra,
            option => option.MapFrom(data => data.Obra))
            .ReverseMap()
            .ForMember(data => data.ControleData,
            option => option.MapFrom(data => data.ControleData));

        CreateMap<DataObra, RetornoDataObraRefeicao>()
            .ForMember(dataDto => dataDto.Obra,
            option => option.MapFrom(data => data.Obra))
            .ReverseMap()
            .ForMember(data => data.ControleData,
            option => option.MapFrom(data => data.ControleData));
    }
}
