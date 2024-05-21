using FortesAlimentacaoApi.Database.Dtos.Refeicao;

namespace FortesAlimentacaoApi.Util.Filtro;

public interface IFiltrarDia
{
    Task<RefeicaoFiltro> Filtrar(AtualizarRefeicao refeicaoDto);
}
