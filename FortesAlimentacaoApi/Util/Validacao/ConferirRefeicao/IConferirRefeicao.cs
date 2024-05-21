using FortesAlimentacaoApi.Database.Dtos.Refeicao;
using FortesAlimentacaoApi.Database.Models;

namespace FortesAlimentacaoApi.Util.Validacao.ConferirRefeicao;

public interface IConferirRefeicao
{
    void Conferir(Refeicao refeicao, AtualizarRefeicao refeicaoDto, TimeOnly horarioRefeicao, TimeSpan diferenca);
}
