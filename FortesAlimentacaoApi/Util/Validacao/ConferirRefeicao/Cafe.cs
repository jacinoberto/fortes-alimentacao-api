using FortesAlimentacaoApi.Database.Dtos.Refeicao;
using FortesAlimentacaoApi.Database.Models;

namespace FortesAlimentacaoApi.Util.Validacao.ConferirRefeicao;

public class Cafe : IConferirRefeicao
{
    public void Conferir(Refeicao refeicao, AtualizarRefeicao refeicaoDto, TimeOnly horarioRefeicao, TimeSpan diferenca)
    {
        if (refeicao.Cafe != refeicaoDto.Cafe)
        {
            DateTime dataHoraRefeicao = refeicao.DataObra.ControleData.DataRefeicao.ToDateTime(horarioRefeicao);
            TimeSpan tempo = dataHoraRefeicao - DateTime.Now;

            if (tempo >= diferenca)
            {
                refeicao.Cafe = refeicaoDto.Cafe;
            }
        }
    }
}
