using FortesAlimentacaoApi.Database.Dtos.Encarregado;
using FortesAlimentacaoApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace FortesAlimentacaoApi.Controllers;

[ApiController]
[Route("api/login")]
public class LoginController : ControllerBase
{
    private readonly EncarregadoService _service;

    public LoginController(EncarregadoService service)
    {
        _service = service;
    }

    [HttpPost("encarregado")]
    public async Task<IActionResult> LoginEncarregado([FromBody] EncarregadoLogin login)
    {
        RetornoEncarregadoLogin? encarregado = await _service.Login(login);
        return encarregado is not null ? Ok(encarregado) : NotFound();
    }
}
