using FortesAlimentacaoApi.Database.Dtos.Refeicao;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Util.Filtro;
using FortesAlimentacaoApi.Util.Validacao.ConferirRefeicao;

namespace FortesAlimentacaoApi.Util.Validacao;

public class ValidarDiaAtipico : IValidarDia
{
    private readonly IFiltrarDia _filtro;
    private readonly IEnumerable<IConferirRefeicao> _refeicoes;

    public ValidarDiaAtipico(IFiltrarDia filtro, IEnumerable<IConferirRefeicao> conferir)
    {
        _filtro = filtro;
        _refeicoes = conferir;
    }

    public async Task<Refeicao> Validar(AtualizarRefeicao atualizarRefeicao)
    {
        IEnumerable<TimeOnly> horarios =
        [
            new(7, 0, 0),
            new(12, 0, 0),
            new(19, 0, 0),
        ];

        RefeicaoFiltro? filtro = await _filtro.Filtrar(atualizarRefeicao);

        if (filtro is not null)
        {
            Refeicao refeicao = filtro.Refeicao;
            AtualizarRefeicao refeicaoDto = filtro.AtualizarRefeicao;

            TimeSpan diferenca = new TimeSpan(0, 12, 0, 0);

            foreach (var iRefeicao in _refeicoes)
            {
                foreach (var horario in horarios)
                {
                    iRefeicao.Conferir(refeicao, refeicaoDto, horario, diferenca);
                }
            }

            return refeicao;
        }

        return null;
    }
}
