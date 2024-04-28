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
    public IActionResult Inserir([FromBody] InserirEquipe equipeDto)
    {
        RetornarEquipe equipe = _service.Inserir(equipeDto);
        return CreatedAtAction(nameof(RetornarPorId),
            new {id = equipe.Id},
            equipe);
    }

    [HttpGet("{id}")]
    public IActionResult RetornarPorId(Guid id)
    {
        if (_service.RetornarPorId(id) is not null) return Ok(_service.RetornarPorId(id));
        else return NotFound();
    }

    [HttpGet]
    public IActionResult RetornarTodos()
    {
        return Ok(_service.RetornarTodos());
    }
}
