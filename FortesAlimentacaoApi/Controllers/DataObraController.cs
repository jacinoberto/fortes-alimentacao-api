using FortesAlimentacaoApi.Database.Dtos.DataObra;
using FortesAlimentacaoApi.Migrations;
using FortesAlimentacaoApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FortesAlimentacaoApi.Controllers;

[Route("api/data-obra")]
[ApiController]
public class DataObraController : ControllerBase
{
    private readonly DataObraService _service;

    public DataObraController(DataObraService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Inserir([FromBody] CriarDataObra dataObraDto)
    {
        return Ok(await _service.Inserir(dataObraDto));
    }
}
