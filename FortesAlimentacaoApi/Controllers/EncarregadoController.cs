using FortesAlimentacaoApi.Database.Dtos.Encarregado;
using FortesAlimentacaoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FortesAlimentacaoApi.Controllers;

[ApiController]
[Route("api/encarregado")]
public class EncarregadoController : ControllerBase
{
    private readonly EncarregadoService _service;

    public EncarregadoController(EncarregadoService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Iserir([FromBody] InserirEncarregado encarregadoDto)
    {
        RetornarEncarregado encarregado = await _service.Inserir(encarregadoDto);
        return CreatedAtAction(nameof(RetornarPorId),
            new { id = encarregado.Id},
            encarregado);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> RetornarPorId(Guid id) 
    {
        if (await _service.RetornarPorId(id) is null) return NotFound();
        else return Ok(await _service.RetornarPorId(id));
    }

    [HttpGet]
    public async Task<IActionResult> RetornarTodos()
    {
        return Ok(await _service.RetornarTodos());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(Guid id)
    {
        if (await _service.Deletar(id)) return NoContent();
        else return NotFound();
    }

    [HttpGet("select")]
    public async Task<IActionResult> EncarregadoSelect([FromQuery] string nome)
    {
        return Ok(await _service.EncarregadoSelect(nome));
    }
}
