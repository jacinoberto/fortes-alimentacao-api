using FortesAlimentacaoApi.Database.Dtos.Relatorio;
using FortesAlimentacaoApi.Util.ValidarDatas;

namespace FortesAlimentacaoApi.Util.VerificarDias.Dias
{
    public class Domingo : IDiaSemanaStrategy
    {
        public DiaSemana? Verificar(DateOnly dataDia)
        {

            if (dataDia.DayOfWeek == DayOfWeek.Sunday)
            {
                DateOnly dataInicial = new DateOnly();
                DateOnly dataFinal = new DateOnly();

                dataInicial = dataDia.AddDays(1);

                dataFinal = dataDia.AddDays(7);
                DiaSemana dia = new(dataInicial, dataFinal);

                return dia;
            }

            return null;
        }
    }
}
