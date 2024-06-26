﻿namespace FortesAlimentacaoApi.Controllers;

using FortesAlimentacaoApi.Database.Dtos.GestaoEquipe;
using FortesAlimentacaoApi.Services;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/gestao-equipe")]
public class GestaoEquipeController : ControllerBase
{
    private readonly GestaoEquipeService _service;

    public GestaoEquipeController(GestaoEquipeService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Inserir([FromBody] InserirGestaoEquipe gestaoDto)
    {
        try
        {
            RetornarGestaoEquipe gestao = await _service.Inserir(gestaoDto);
            return CreatedAtAction(nameof(RetornarPorId),
                new { id = gestao.Id },
                gestao);
        }
        catch (Exception ex)
        {
            var retorno = Content(ex.Message);
            retorno.StatusCode = 500;
            return retorno;
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> RetornarPorId(Guid id)
    {
        return Ok(await _service.RetornarPorId(id));
    }

    [HttpGet]
    public async Task<IActionResult> RetornarTodos()
    {
        return Ok(await _service.RetornarTodos());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Deletar(Guid id) 
    {
        if (await _service.Deletar(id)) return NoContent();
        else return NotFound();
    }
}
