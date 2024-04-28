using FortesAlimentacaoApi.Database.Dtos.Admin;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FortesAlimentacaoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AdminController : ControllerBase
{
    private AdminService _service;

    public AdminController(AdminService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Insert([FromBody] InserirAdmin adminDto)
    {
        RetornoAdmin admin = _service.Inserir(adminDto);
        return CreatedAtAction(nameof(GetById),
            new {id = admin.Id},
            admin);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.RetornarTodos());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id) 
    {
        if (_service.RetornarPorId(id) is null) return NotFound();

        return Ok(_service.RetornarPorId(id));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id) 
    {
        if (!_service.Deletar(id)) return NotFound();

        _service.Deletar(id);
        return NoContent();
    }
}
