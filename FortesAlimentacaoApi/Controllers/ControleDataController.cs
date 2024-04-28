using FortesAlimentacaoApi.Database.Dtos.ControleData;
using FortesAlimentacaoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FortesAlimentacaoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ControleDataController : ControllerBase
{
    private readonly ControleDataService _service;

    public ControleDataController(ControleDataService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Inserir([FromBody] InserirControleData controleDataDto)
    {
        RetornarControleData controleData = _service.Inserir(controleDataDto);
        return CreatedAtAction(nameof(RetornarPorId),
            new {id = controleData.Id}, controleData);
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
