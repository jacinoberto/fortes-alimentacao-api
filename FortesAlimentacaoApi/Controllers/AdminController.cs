using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Admin;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using Microsoft.AspNetCore.Mvc;

namespace FortesAlimentacaoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AdminController : ControllerBase
{
    private FortesAlimentacaoDbContext _context;
    private IMapper _mapper;

    public AdminController(FortesAlimentacaoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult Insert([FromBody] InserirAdmin adminDto)
    {
        Admin admin = _mapper.Map<Admin>(adminDto);
        _context.Add(admin);
        _context.SaveChanges();
        return Ok(adminDto);
    }
}
