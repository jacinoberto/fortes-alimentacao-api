using FortesAlimentacaoApi.Database.Dtos.Operario;
using FortesAlimentacaoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FortesAlimentacaoApi.Controllers;

[ApiController]
[Route("api/operario")]
public class OperarioController : ControllerBase
{
    private OperarioService _service;

    public OperarioController(OperarioService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Inserir([FromBody] InserirOperario operarioDto)
    {
        RetornarOperario operario = await _service.Inserir(operarioDto);
        return CreatedAtAction(nameof(RetornarPorId),
            new {id =  operario.Id},
            operario);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> RetornarPorId(Guid id)
    {
        if (await _service.RetornarPorId(id) is null) return NotFound();

        return Ok(await _service.RetornarPorId(id));
    }

    [HttpGet]
    public async Task<IActionResult> RetornarTodos()
    {
        return Ok(await _service.RetornarTodos());
    }

    [HttpGet("select")]
    public async Task<IActionResult> RetornarSelect([FromQuery] string nome)
    {
        return Ok(await _service.RetornarSelect(nome));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        if(!await _service.Deletar(id)) return NotFound();
        
        await _service.Deletar(id);
        return NoContent();
    }
}
