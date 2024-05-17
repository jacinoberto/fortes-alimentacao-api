using FortesAlimentacaoApi.Database.Dtos.Admin;
using FortesAlimentacaoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FortesAlimentacaoApi.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    private AdminService _service;

    public AdminController(AdminService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] InserirAdmin adminDto)
    {
        RetornoAdmin admin = await _service.Inserir(adminDto);
        return CreatedAtAction(nameof(GetById),
            new {id = admin.Id},
            admin);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.RetornarTodos());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id) 
    {
        if (await _service.RetornarPorId(id) is null) return NotFound();

        return Ok(await _service.RetornarPorId(id));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id) 
    {
        if (!await _service.Deletar(id)) return NotFound();

        await _service.Deletar(id);
        return NoContent();
    }
}
