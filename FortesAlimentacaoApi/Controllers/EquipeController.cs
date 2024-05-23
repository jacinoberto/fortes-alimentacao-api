using FortesAlimentacaoApi.Database.Dtos.Equipe;
using FortesAlimentacaoApi.Database.Dtos.Operario;
using FortesAlimentacaoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FortesAlimentacaoApi.Controllers;

[ApiController]
[Route("api/equipe")]
public class EquipeController : ControllerBase
{
    private readonly EquipeService _service;

    public EquipeController(EquipeService service)
    {
        _service = service;
    }

    [HttpPost("{idGestaoEquipe}")]
    public async Task<IActionResult> Inserir([FromBody] IEnumerable<InserirOperario> operarios, Guid idGestaoEquipe)
    {
        try
        {
            await _service.Inserir(operarios, idGestaoEquipe);
            return Ok("Operario cadastrado e vinculado a equipe com sucesso.");

        }
        catch (Exception ex)
        {
            return BadRequest("Algo inesperado aconteceu.");
        }
        

       // if (_service.Inserir(operarios, idGestaoEquipe).IsCompleted) return Ok();
       // else return BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> RetornarPorId(Guid id)
    {
        if (await _service.RetornarPorId(id) is not null) return Ok(await _service.RetornarPorId(id));
        else return NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> RetornarTodos()
    {
        return Ok(await _service.RetornarTodos());
    }
}
