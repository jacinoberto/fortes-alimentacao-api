using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Admin;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using System.Collections.ObjectModel;

namespace FortesAlimentacaoApi.Services.AdminService;

public class AdminService : IAdminService
{
    private FortesAlimentacaoDbContext _context;
    private IMapper _mapper;

    public AdminService(FortesAlimentacaoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Collection<RetornoAdmin> GetAll()
    {
        return _mapper.Map<Collection<RetornoAdmin>>(_context.Admins.ToList());
    }

    public RetornoAdmin GeteById(Guid id)
    {
        Admin admin = _context.Admins.FirstOrDefault(admin => admin.Id == id);
        return _mapper.Map<RetornoAdmin>(admin);
    }

    public RetornoAdmin Insert(InserirAdmin entity)
    {
        Admin admin = _mapper.Map<Admin>(entity);
        _context.Add(admin);
        _context.SaveChanges();

        return _mapper.Map<RetornoAdmin>(admin);
    }

    public void Update(Guid id, AtualizarAdmin entity)
    {
        throw new NotImplementedException();
    }
    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}
