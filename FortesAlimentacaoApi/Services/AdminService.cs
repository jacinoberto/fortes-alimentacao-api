using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Admin;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using System.Collections.ObjectModel;

namespace FortesAlimentacaoApi.Services;

public class AdminService : IServiceGlobal<InserirAdmin, RetornoAdmin, AtualizarAdmin>
{
    private readonly FortesAlimentacaoDbContext _context;
    private readonly IMapper _mapper;

    public AdminService(FortesAlimentacaoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<RetornoAdmin> RetornarTodos()
    {
        return _mapper.Map<Collection<RetornoAdmin>>(_context.Admins.ToList());
    }

    public RetornoAdmin RetornarPorId(Guid id)
    {
        Admin admin = _context.Admins
            .FirstOrDefault(admin => admin.Id == id);

        return _mapper.Map<RetornoAdmin>(admin);
    }

    public RetornoAdmin Inserir(InserirAdmin entity)
    {
        Admin admin = _mapper.Map<Admin>(entity);
        _context.Add(admin);
        _context.SaveChanges();

        return _mapper.Map<RetornoAdmin>(admin);
    }

    public void Atualizar(Guid id, AtualizarAdmin entity)
    {
        throw new NotImplementedException();
    }

    public bool Deletar(Guid id)
    {
        if (_context.Admins.FirstOrDefault(admin => admin.Id == id) is null) return false;

        _context.Admins.Remove(_context.Admins
            .FirstOrDefault(admin => admin.Id == id));
        _context.SaveChanges();

        return true;
    }
}
