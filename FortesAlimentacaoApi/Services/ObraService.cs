using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Obra;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FortesAlimentacaoApi.Services;

public class ObraService : IGlobalService<InserirObra, RetornarObra, AtualizarObra>
{
    private readonly FortesAlimentacaoDbContext _context;
    private readonly IMapper _mapper;

    public ObraService(FortesAlimentacaoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public RetornarObra Inserir(InserirObra entity)
    {
        Obra obra = _mapper.Map<Obra>(entity);
        _context.Obras.Add(obra);
        _context.SaveChanges();

        return _mapper.Map<RetornarObra>(obra);
    }

    public RetornarObra RetornarPorId(Guid id)
    {
        return _mapper.Map<RetornarObra>(
            _context.Obras.Include(obra => obra.Endereco)
            .FirstOrDefault(obra => obra.Id == id));
    }

    public IEnumerable<RetornarObra> RetornarTodos()
    {
        return _mapper.Map<IEnumerable<RetornarObra>>(
            _context.Obras.Include(obra => obra.Endereco).ToList());
    }
    public void Atualizar(Guid id, AtualizarObra entity)
    {
        throw new NotImplementedException();
    }

    public bool Deletar(Guid id)
    {
        throw new NotImplementedException();
    }
}
