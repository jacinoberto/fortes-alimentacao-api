using FortesAlimentacaoApi.Database.Dtos.Relatorio;
using FortesAlimentacaoApi.Util.ValidarDatas;

namespace FortesAlimentacaoApi.Util.VerificarDias.Dias
{
    public class Sexta : IDiaSemanaStrategy
    {
        public DiaSemana? Verificar(DateOnly dataDia)
        {

            if (dataDia.DayOfWeek is DayOfWeek.Friday)
            {
                DateOnly dataInicial = new DateOnly();
                DateOnly dataFinal = new DateOnly();
                dataInicial = dataDia.AddDays(3);

                dataFinal = dataDia.AddDays(9);
                DiaSemana dia = new(dataInicial, dataFinal);

                return dia;
            }

            return null;
        }
    }
}
