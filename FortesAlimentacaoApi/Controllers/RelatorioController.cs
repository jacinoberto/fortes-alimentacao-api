using FortesAlimentacaoApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FortesAlimentacaoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly RelatorioService _service;

        public RelatorioController(RelatorioService service)
        {
            _service = service;
        }

        [HttpGet("automatico")]
        public async Task<IActionResult> Retorno()
        {
            return Ok(await _service.Relatorio());
        }

        [HttpGet]
        public async Task<IActionResult> Retorno([FromQuery] DateOnly dataInicial, [FromQuery] DateOnly dataFinal)
        {
            return Ok(await _service.Relatorio(dataInicial, dataFinal));
        }
    }
}
