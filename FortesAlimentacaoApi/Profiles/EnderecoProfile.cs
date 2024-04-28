using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Endereco;
using FortesAlimentacaoApi.Database.Models;

namespace FortesAlimentacaoApi.Profiles;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<EnderecoDto, Endereco>();
        CreateMap<Endereco, EnderecoDto>();
    }
}
