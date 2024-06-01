namespace FortesAlimentacaoApi.Controllers;

using FortesAlimentacaoApi.Services;
using FortesAlimentacaoApi.Database.Dtos.Encarregado;
using Microsoft.AspNetCore.Mvc;
using FortesAlimentacaoApi.Database.Dtos.GestaoEquipe;
using FortesAlimentacaoApi.Database.Dtos.Operario;
using FortesAlimentacaoApi.Database.Dtos.Obra;

[Route("api/select")]
[ApiController]
public class SelectController : ControllerBase
{
    private readonly SelectService _service;

    public SelectController(SelectService service)
    {
        _service = service;
    }

    [HttpGet("encarregado")]
    public async Task<IActionResult> SelectEncarregadoAsync()
    {
        IEnumerable<EncarregadoSelect> encarregados = await _service.SelectEncarregadoAsync();
        return encarregados is not null ? Ok(encarregados) : NotFound();
    }

    [HttpGet("gestao-equipe")]
    public async Task<IActionResult> SelectGestaoEquipeAsync()
    {
        IEnumerable<GestaoEquipeSelect> gestoes = await _service.SelectGestaoEquipeAsync();
        return gestoes is not null ? Ok(gestoes) : NotFound();
    }

    [HttpGet("operario")]
    public async Task<IActionResult> SelectOperarioAsync([FromQuery] string nome)
    {
        IEnumerable<OperarioSelect> operarios = await _service.SelectOperarioAsync(nome);
        return operarios is not null ? Ok(operarios) : NotFound();
    }

    [HttpGet("obra")]
    public async Task<IActionResult> SelectObraAsync()
    {
        IEnumerable<ObraSelectData> obras = await _service.SelectObraAsync();
        return obras is not null ? Ok(obras) : NotFound();
    }
}
