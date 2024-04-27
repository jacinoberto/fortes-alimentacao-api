using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Admin;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using FortesAlimentacaoApi.Services.AdminService;
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
        return Ok(_service.Insert(adminDto));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id) 
    {
        return Ok(_service.GeteById(id));
    }
}
