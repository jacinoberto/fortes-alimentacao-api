using FortesAlimentacaoApi.Database.Dtos.Relatorio;
using FortesAlimentacaoApi.Util.ValidarDatas;

namespace FortesAlimentacaoApi.Util.VerificarDias.Dias
{
    public class Quarta : IDiaSemanaStrategy
    {
        public DiaSemana? Verificar(DateOnly dataDia)
        {

            if (dataDia.DayOfWeek is DayOfWeek.Wednesday)
            {
                DateOnly dataInicial = new DateOnly();
                DateOnly dataFinal = new DateOnly();
                dataInicial = dataDia.AddDays(-2);

                dataFinal = dataDia.AddDays(4);
                DiaSemana dia = new(dataInicial, dataFinal);

                return dia;
            }

            return null;
        }
    }
}
