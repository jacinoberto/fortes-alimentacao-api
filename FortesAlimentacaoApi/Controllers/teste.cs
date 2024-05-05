using Microsoft.AspNetCore.Mvc;

namespace FortesAlimentacaoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class teste
{
    [HttpGet]
    public string testes()
    {
        var dia = DateTime.Today.DayOfWeek;

        DateTime data = new DateTime(2024,05,02,14,0,0);

        DateTime agora = DateTime.Now;

        TimeSpan diferenca = data - agora;

        DateOnly d = new DateOnly(2024,05,05);
        TimeOnly t = new TimeOnly(09,56,0);

        DateOnly e = new DateOnly(2024, 05, 06);
        TimeOnly j = new TimeOnly(12, 0, 0);

        DateTime ttt = d.ToDateTime(t);
        DateTime ddd = e.ToDateTime(j);

        TimeSpan teste = ddd - ttt;

        TimeSpan teste2 = new(2,1,30,0);

        if(teste >= teste2)
        {
            Console.WriteLine(true);
        }
        else Console.WriteLine(false);

        DateOnly dataDia = DateOnly.FromDateTime(DateTime.Today);

        for (int i =1; i <= 7; i++)
        {
            dataDia = dataDia.AddDays(1);

            Console.WriteLine(dataDia);
        }

        return dia.ToString();
    }
}
