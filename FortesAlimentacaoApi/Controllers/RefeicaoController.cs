using FortesAlimentacaoApi.Database.Dtos.Refeicao;
using FortesAlimentacaoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FortesAlimentacaoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RefeicaoController : ControllerBase
{
    private readonly RefeicaoService _service;

    public RefeicaoController(RefeicaoService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Inserir([FromBody] InserirRefeicao refeicaoDto)
    {
        RetornarRefeicao refeicao = _service.Inserir(refeicaoDto);

        return CreatedAtAction(nameof(RetornarPorId),
            new { id = refeicao.Id },
            refeicao);
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
}
