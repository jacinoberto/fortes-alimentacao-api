using FortesAlimentacaoApi.Database.Dtos.Relatorio;
using FortesAlimentacaoApi.Util.ValidarDatas;

namespace FortesAlimentacaoApi.Util.VerificarDias.Dias
{
    public class Quinta : IDiaSemanaStrategy
    {
        public DiaSemana? Verificar(DateOnly dataDia)
        {


            if (dataDia.DayOfWeek is DayOfWeek.Thursday)
            {
                DateOnly dataInicial = new DateOnly();
                DateOnly dataFinal = new DateOnly();
                dataInicial = dataDia.AddDays(4);

                dataFinal = dataDia.AddDays(10);
                DiaSemana dia = new(dataInicial, dataFinal);

                return dia;
            }

            return null;
        }
    }
}
