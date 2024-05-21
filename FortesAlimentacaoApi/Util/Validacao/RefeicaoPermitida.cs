using FortesAlimentacaoApi.Database.Dtos.Refeicao;
using FortesAlimentacaoApi.Database.Models;

namespace FortesAlimentacaoApi.Util.Validacao;

public class RefeicaoPermitida
{
    private readonly IValidarDia _validar;

    public RefeicaoPermitida(IValidarDia validar)
    {
        _validar = validar;
    }

    public async Task<Refeicao> RefeicoesPermitidasAtualizacoes(AtualizarRefeicao refeicaoDto)
    {
        if (await _validar.Validar(refeicaoDto) is not null) return await _validar.Validar(refeicaoDto);

        return null;
    }
}
