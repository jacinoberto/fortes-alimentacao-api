using FortesAlimentacaoApi.Database.Dtos.Operario;
using FortesAlimentacaoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FortesAlimentacaoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OperarioController : ControllerBase
{
    private OperarioService _service;

    public OperarioController(OperarioService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Inserir([FromBody] InserirOperario operarioDto)
    {
        RetornarOperario operario = _service.Inserir(operarioDto);
        return CreatedAtAction(nameof(RetornarPorId),
            new {id =  operario.Id},
            operario);
    }

    [HttpGet("{id}")]
    public IActionResult RetornarPorId(Guid id)
    {
        if (_service.RetornarPorId(id) is null) return NotFound();

        return Ok(_service.RetornarPorId(id));
    }

    [HttpGet]
    public IActionResult RetornarTodos()
    {
        return Ok(_service.RetornarTodos());
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        if(!_service.Deletar(id)) return NotFound();
        
        _service.Deletar(id);
        return NoContent();
    }
}
