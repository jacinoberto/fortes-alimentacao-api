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

        CreateMap<Admin, RetornoAdmin>()
            .ForMember(adminDto => adminDto.Gestor,
            option => option.MapFrom(admin => admin.Gestor))
            .ReverseMap();
    }
}
