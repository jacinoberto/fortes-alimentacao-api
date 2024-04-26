using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Operario;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using Microsoft.AspNetCore.Mvc;

namespace FortesAlimentacaoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OperarioController : ControllerBase
{
    private FortesAlimentacaoDbContext _context;
    private IMapper _mapper;

    public OperarioController(FortesAlimentacaoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult Inserir([FromBody] InserirOperario operarioDto)
    {
        Operario operario = _mapper.Map<Operario>(operarioDto);
        _context.Add(operario);
        _context.SaveChanges();
        return Ok(operarioDto);
    }
}
