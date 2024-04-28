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
    public IActionResult Inserir([FromBody] InserirObra obraDto)
    {
        RetornarObra obra = _service.Inserir(obraDto);
        return CreatedAtAction(nameof(RetornarPorId),
            new { id = obra.Id },
            obra);
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
}
