using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.ControleData;
using FortesAlimentacaoApi.Database.Dtos.Refeicao;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FortesAlimentacaoApi.Util;

public class AbrirAgenda
{
    private FortesAlimentacaoDbContext _context;
    private IMapper _mapper;


    public AbrirAgenda(FortesAlimentacaoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task ConferirControleDatas(IEnumerable<ControleData> datas)
    {
        DateOnly dataDia = DateOnly.FromDateTime(DateTime.Today).AddDays(3);

        for (int i = 1; i <= 7; i++)
        {
            dataDia = dataDia.AddDays(1);

            ControleData? controleData = await _context.ControleDatas
                .FirstOrDefaultAsync(data => data.DataRefeicao == dataDia);

            if (controleData is null)
            {
                InserirControleData data = new(dataDia, null, false);
                await _context.AddAsync(_mapper.Map<ControleData>(data));
                await _context.SaveChangesAsync();
            }
        }
    }

    public async Task AberturaDeAgenda(IEnumerable<Equipe> equipes, IEnumerable<ControleData> datas)
    {
        await ConferirControleDatas(datas);

        var data = DateTime.Today.DayOfWeek;

        if (data is DayOfWeek.Thursday)
        {
            IEnumerable<ControleData> datasValidas = [];

            await Task.Run(() => 
            {
                datasValidas = _context.ControleDatas
                .Where(data => data.DataRefeicao > DateOnly.FromDateTime(DateTime.Today).AddDays(3)
                && data.DataRefeicao < data.DataRefeicao.AddDays(7))
                .ToList();
            });           
            
            foreach (ControleData controleData in datasValidas)
            {
                foreach (Equipe equipe in equipes)
                {

                    InserirRefeicao refeicaoDto = new InserirRefeicao(
                        equipe.Id,
                        controleData.Id
                        );

                    await _context.Refeicoes.AddAsync(_mapper.Map<Refeicao>(refeicaoDto));
                    await _context.SaveChangesAsync();
                }                    
            }
        }
    }
}
