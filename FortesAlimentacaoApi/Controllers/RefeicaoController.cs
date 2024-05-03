using FortesAlimentacaoApi.Database.Dtos.Refeicao;
using FortesAlimentacaoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FortesAlimentacaoApi.Controllers;

[ApiController]
[Route("api/refeicao")]
public class RefeicaoController : ControllerBase
{
    private readonly RefeicaoService _service;

    public RefeicaoController(RefeicaoService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Inserir([FromBody] InserirRefeicao refeicaoDto)
    {
        RetornarRefeicao refeicao = await _service.Inserir(refeicaoDto);

        return CreatedAtAction(nameof(RetornarPorId),
            new { id = refeicao.Id },
            refeicao);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> RetornarPorId(Guid id)
    {
        return Ok(await _service.RetornarPorId(id));
    }

    [HttpGet]
    public async Task<IActionResult> RetornarTodos()
    {
        return Ok(await _service.RetornarTodos());
    }

    [HttpGet("equipe/{id}")]
    public async Task<IActionResult> RetornarTodosPorIdEncarregado(Guid id)
    {
        return Ok(await _service.RetornarTodosPorIdEncarregado(id));
    }

    [HttpPost("agenda")]
    public IActionResult Agendar()
    {
        _service.Agenda();
        return Ok();
    }
}
