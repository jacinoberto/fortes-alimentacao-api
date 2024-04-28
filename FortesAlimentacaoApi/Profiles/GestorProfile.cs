namespace FortesAlimentacaoApi.Profiles;

using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Gestor;
using FortesAlimentacaoApi.Database.Models;

public class GestorProfile : Profile
{
    public GestorProfile()
    {
        CreateMap<InserirGestor, Gestor>();
        CreateMap<Gestor, RetornarGestor>();
        CreateMap<Gestor, RetornoGestorGestao>();
    }
}
