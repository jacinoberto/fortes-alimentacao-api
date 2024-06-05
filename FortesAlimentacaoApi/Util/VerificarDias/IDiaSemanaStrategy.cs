using FortesAlimentacaoApi.Database.Dtos.Relatorio;

namespace FortesAlimentacaoApi.Util.ValidarDatas;

public interface IDiaSemanaStrategy
{
    DiaSemana? Verificar(DateOnly dataDia);
}
