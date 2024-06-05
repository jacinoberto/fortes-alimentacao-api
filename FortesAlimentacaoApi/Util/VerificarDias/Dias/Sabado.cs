using FortesAlimentacaoApi.Database.Dtos.Relatorio;
using FortesAlimentacaoApi.Util.ValidarDatas;

namespace FortesAlimentacaoApi.Util.VerificarDias.Dias
{
    public class Sabado : IDiaSemanaStrategy
    {
        public DiaSemana? Verificar(DateOnly dataDia)
        {

            if (dataDia.DayOfWeek is DayOfWeek.Saturday)
            {
                DateOnly dataInicial = new DateOnly();
                DateOnly dataFinal = new DateOnly();

                dataInicial = dataDia.AddDays(2);

                dataFinal = dataDia.AddDays(8);

                DiaSemana dia = new(dataInicial, dataFinal);

                return dia;
            }

            return null;
        }
    }
}
