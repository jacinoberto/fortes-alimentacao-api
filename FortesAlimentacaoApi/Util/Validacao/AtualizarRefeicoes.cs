using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Refeicao;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace FortesAlimentacaoApi.Util.Validacao;

public class AtualizarRefeicoes
{
    private readonly FortesAlimentacaoDbContext _context;
    private readonly IMapper _mapper;

    public AtualizarRefeicoes(FortesAlimentacaoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Collection<RetornarRefeicao>> RefeicoesAtualizadas(Collection<Refeicao> refeicoes)
    {
        Collection<RetornarRefeicao> refeicoesAtualizadas = [];

        foreach (Refeicao refeicao in refeicoes)
        {
            Refeicao? refe = await _context.Refeicoes.FirstOrDefaultAsync(r => r.Id == refeicao.Id);

            if (refe is not null)
            {
                refe.Cafe = refeicao.Cafe;
                refe.Almoco = refeicao.Almoco;
                refe.Jantar = refeicao.Jantar;
                await _context.SaveChangesAsync();
            }

            refeicoesAtualizadas.Add(_mapper.Map<RetornarRefeicao>(refeicao));
        }

        return refeicoesAtualizadas;
    }
}
