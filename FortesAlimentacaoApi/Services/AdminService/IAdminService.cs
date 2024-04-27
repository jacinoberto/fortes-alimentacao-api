using FortesAlimentacaoApi.Database.Dtos.Admin;

namespace FortesAlimentacaoApi.Services.AdminService;

public interface IAdminService : IServiceGlobal<InserirAdmin, RetornoAdmin, AtualizarAdmin>
{
}
