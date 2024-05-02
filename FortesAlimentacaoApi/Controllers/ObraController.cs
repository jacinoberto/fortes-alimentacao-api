using FortesAlimentacaoApi.Database.Dtos.Obra;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FortesAlimentacaoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ObraController : ControllerBase
{
    private readonly ObraService _service;

    public ObraController(ObraService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Inserir([FromBody] InserirObra obraDto)
    {
        RetornarObra obra = await _service.Inserir(obraDto);
        return CreatedAtAction(nameof(RetornarPorId),
            new { id = obra.Id },
            obra);
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
}
