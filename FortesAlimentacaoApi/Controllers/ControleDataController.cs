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
    public async Task<IActionResult> Inserir([FromBody] InserirControleData controleDataDto)
    {
        RetornarControleData controleData = await _service.Inserir(controleDataDto);
        return CreatedAtAction(nameof(RetornarPorId),
            new {id = controleData.Id}, controleData);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> RetornarPorId(Guid id)
    {
        if (await _service.RetornarPorId(id) is not null) return Ok(await _service.RetornarPorId(id));
        else return NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> RetornarTodos()
    {
        return Ok(await _service.RetornarTodos());
    }
}
