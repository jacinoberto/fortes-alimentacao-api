using FortesAlimentacaoApi.Database.Dtos.Refeicao;
using FortesAlimentacaoApi.Database.Models;

namespace FortesAlimentacaoApi.Util.Validacao.ConferirRefeicao;

public class Jantar : IConferirRefeicao
{
    public void Conferir(Refeicao refeicao, AtualizarRefeicao refeicaoDto, TimeOnly horarioRefeicao, TimeSpan diferenca)
    {
        if (refeicao.Jantar != refeicaoDto.Jantar)
        {
            DateTime dataHoraRefeicao = refeicao.DataObra.ControleData.DataRefeicao.ToDateTime(horarioRefeicao);
            TimeSpan tempo = dataHoraRefeicao - DateTime.Now;
            if (tempo >= diferenca)
            {
                refeicao.Jantar = refeicaoDto.Jantar;
            }
        }
    }
}
