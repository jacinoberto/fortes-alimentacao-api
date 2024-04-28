using FortesAlimentacaoApi.Database.Dtos.Encarregado;
using FortesAlimentacaoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FortesAlimentacaoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EncarregadoController : ControllerBase
{
    private readonly EncarregadoService _service;

    public EncarregadoController(EncarregadoService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Iserir([FromBody] InserirEncarregado encarregadoDto)
    {
        RetornarEncarregado encarregado = _service.Inserir(encarregadoDto);
        return CreatedAtAction(nameof(RetornarPorId),
            new { id = encarregado.Id},
            encarregado);
    }

    [HttpGet("{id}")]
    public IActionResult RetornarPorId(Guid id) 
    {
        if (_service.RetornarPorId(id) is null) return NotFound();
        else return Ok(_service.RetornarPorId(id));
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
