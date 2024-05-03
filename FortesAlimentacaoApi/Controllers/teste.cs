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

        Console.WriteLine(diferenca);

        return dia.ToString();
    }
}
