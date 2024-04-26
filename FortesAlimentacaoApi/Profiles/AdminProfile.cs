namespace FortesAlimentacaoApi.Profiles;

using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Admin;
using FortesAlimentacaoApi.Database.Models;

public class AdminProfile : Profile
{
    public AdminProfile()
    {
        CreateMap<InserirAdmin, Admin>()
            .ForMember(admin => admin.Gestor,
            option => option.MapFrom(adminDto => adminDto.Gestor))
            .ReverseMap();
    }
}
