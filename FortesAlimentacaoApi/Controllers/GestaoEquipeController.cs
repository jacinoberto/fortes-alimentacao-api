namespace FortesAlimentacaoApi.Controllers;

using FortesAlimentacaoApi.Database.Dtos.GestaoEquipe;
using FortesAlimentacaoApi.Services;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class GestaoEquipeController : ControllerBase
{
    private readonly GestaoEquipeService _service;

    public GestaoEquipeController(GestaoEquipeService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Inserir([FromBody] InserirGestaoEquipe gestaoDto)
    {
        RetornarGestaoEquipe gestao = _service.Inserir(gestaoDto);
        return CreatedAtAction(nameof(RetornarPorId),
            new { id = gestao.Id },
            gestao);
    }

    [HttpGet("{id}")]
    public IActionResult RetornarPorId(Guid id)
    {
        return Ok(_service.RetornarPorId(id));
    }

    [HttpGet]
    public IActionResult RetornarTodos()
    {
        return Ok(_service.RetornarTodos());
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id) 
    {
        if (_service.Deletar(id)) return NoContent();
        else return NotFound();
    }
}
