using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Admin;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace FortesAlimentacaoApi.Services;

public class AdminService : IGlobalService<InserirAdmin, RetornoAdmin>
{
    private readonly FortesAlimentacaoDbContext _context;
    private readonly IMapper _mapper;

    public AdminService(FortesAlimentacaoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RetornoAdmin>> RetornarTodos()
    {
        return _mapper.Map<Collection<RetornoAdmin>>(await _context.Admins.ToListAsync());
    }

    public async Task<RetornoAdmin> RetornarPorId(Guid id)
    {

        return _mapper.Map<RetornoAdmin>(await _context.Admins
            .FirstOrDefaultAsync(admin => admin.Id == id));
    }

    public async Task<RetornoAdmin> Inserir(InserirAdmin entity)
    {
            Admin admin = _mapper.Map<Admin>(entity);
            await _context.AddAsync(admin);
            await _context.SaveChangesAsync();

            return _mapper.Map<RetornoAdmin>(admin);
    }

    public async Task<bool> Deletar(Guid id)
    {
        Admin? admin = await _context.Admins.FirstOrDefaultAsync(admin => admin.Id == id);

        if (admin is not null)
        {
            admin.Gestor.InvativarPerfil();
            await _context.SaveChangesAsync();
            return true;
        }
        else return false;
    }
}
