using FortesAlimentacaoApi.Database.Dtos.Equipe;
using FortesAlimentacaoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FortesAlimentacaoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EquipeController : ControllerBase
{
    private readonly EquipeService _service;

    public EquipeController(EquipeService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Inserir([FromBody] InserirEquipe equipeDto)
    {
        RetornarEquipe equipe = await _service.Inserir(equipeDto);
        return CreatedAtAction(nameof(RetornarPorId),
            new {id = equipe.Id},
            equipe);
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
