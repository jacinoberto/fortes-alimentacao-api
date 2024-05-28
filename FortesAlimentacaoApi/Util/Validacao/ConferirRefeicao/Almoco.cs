using FortesAlimentacaoApi.Database.Dtos.Refeicao;
using FortesAlimentacaoApi.Database.Models;

namespace FortesAlimentacaoApi.Util.Validacao.ConferirRefeicao;

public class Almoco : IConferirRefeicao
{
    public void Conferir(Refeicao refeicao, AtualizarRefeicao refeicaoDto, TimeOnly horarioRefeicao, TimeSpan diferenca)
    {
        if (refeicao.Almoco != refeicaoDto.Almoco)
        {
            DateTime dataHoraRefeicao = refeicao.DataObra.ControleData.DataRefeicao.ToDateTime(horarioRefeicao);
            TimeSpan tempo = dataHoraRefeicao - DateTime.Now;

            if (tempo >= diferenca)
            {
                refeicao.Almoco = refeicaoDto.Almoco;
            }
        }
    }
}
