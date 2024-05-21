using FortesAlimentacaoApi.Database.Dtos.Refeicao;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Util.Filtro;

namespace FortesAlimentacaoApi.Util.Validacao;

public class ValidarDiaNaoAtipico : IValidarDia
{
    private readonly IFiltrarDia _filtro;

    public ValidarDiaNaoAtipico(IFiltrarDia filtro)
    {
        _filtro = filtro;
    }

    public async Task<Refeicao> Validar(AtualizarRefeicao atualizarRefeicao)
    {
        TimeOnly cafe = new(7, 0, 0);
        TimeOnly almoco = new(12, 0, 0);
        TimeOnly jantar = new(19, 0, 0);

        RefeicaoFiltro? filtro = await _filtro.Filtrar(atualizarRefeicao);

        if (filtro is not null)
        {
            Refeicao refeicao = filtro.Refeicao;
            AtualizarRefeicao refeicaoDto = filtro.AtualizarRefeicao;

            DateTime dataHoraAtual = DateTime.Now;
            DateTime dataHoraRefeicao = new DateTime();
            TimeSpan diferenca = new TimeSpan(2, 0, 0, 0);
            TimeSpan tempo = new TimeSpan();

            if (refeicao.Cafe != refeicaoDto.Cafe)
            {
                dataHoraRefeicao = refeicao.ControleData.DataRefeicao.ToDateTime(cafe);
                tempo = dataHoraRefeicao - dataHoraAtual;

                Console.WriteLine(tempo);
                if (tempo >= diferenca)
                {
                    refeicao.Cafe = refeicaoDto.Cafe;
                }
            }

            if (refeicao.Almoco != refeicaoDto.Almoco)
            {
                dataHoraRefeicao = refeicao.ControleData.DataRefeicao.ToDateTime(almoco);
                tempo = dataHoraRefeicao - dataHoraAtual;

                Console.WriteLine(tempo);
                if (tempo >= diferenca)
                {
                    refeicao.Almoco = refeicaoDto.Almoco;
                }
            }

            if (refeicao.Jantar != refeicaoDto.Jantar)
            {
                dataHoraRefeicao = refeicao.ControleData.DataRefeicao.ToDateTime(jantar);
                tempo = dataHoraRefeicao - dataHoraAtual;
                if (tempo >= diferenca)
                {
                    refeicao.Jantar = refeicaoDto.Jantar;
                }
            }

            return refeicao;
        }

        return null;
    }
}
