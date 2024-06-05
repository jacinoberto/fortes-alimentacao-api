using FortesAlimentacaoApi.Database.Dtos.Relatorio;
using FortesAlimentacaoApi.Util.ValidarDatas;

namespace FortesAlimentacaoApi.Util.VerificarDias.Dias;

public class Terca : IDiaSemanaStrategy
{
    public DiaSemana? Verificar(DateOnly dataDia)
    {

        if (dataDia.DayOfWeek == DayOfWeek.Tuesday)
        {
            DateOnly dataInicial = new DateOnly();
            DateOnly dataFinal = new DateOnly();

            dataInicial = dataDia.AddDays(-1);

            dataFinal = dataDia.AddDays(5);
            DiaSemana dia = new(dataInicial, dataFinal);

            return dia;
        }

        return null;
    }
}
