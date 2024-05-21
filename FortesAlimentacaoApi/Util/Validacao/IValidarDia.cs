using FortesAlimentacaoApi.Database.Dtos.Refeicao;
using FortesAlimentacaoApi.Database.Models;

namespace FortesAlimentacaoApi.Util.Validacao;

public interface IValidarDia
{
    Task<Refeicao> Validar(AtualizarRefeicao refeicaoDto);
}
