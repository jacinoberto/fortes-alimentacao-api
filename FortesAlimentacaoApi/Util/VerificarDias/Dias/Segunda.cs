using FortesAlimentacaoApi.Database.Dtos.Relatorio;
using FortesAlimentacaoApi.Infra.Context;
using FortesAlimentacaoApi.Util.ValidarDatas;

namespace FortesAlimentacaoApi.Util.VerificarDias.Dias;

public class Segunda : IDiaSemanaStrategy
{



    public DiaSemana? Verificar(DateOnly dataDia)
    {

        if (dataDia.DayOfWeek == DayOfWeek.Monday)
        {
            DateOnly dataInicial = new DateOnly();
            DateOnly dataFinal = new DateOnly();

            dataInicial = dataDia;

            dataFinal = dataDia.AddDays(6);

            DiaSemana dia = new(dataInicial, dataFinal);

            return dia;
        }

        return null;
    }
}
