namespace FortesAlimentacaoApi.Services;

using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Operario;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;

public class OperarioService : IGlobalService<InserirOperario, RetornarOperario, AtualizarOperario>
{
    private readonly FortesAlimentacaoDbContext _context;
    private readonly IMapper _mapper;

    public OperarioService(FortesAlimentacaoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<RetornarOperario> RetornarTodos()
    {
        return _mapper.Map<IEnumerable<RetornarOperario>>(
            _context.Operarios.Where<Operario>(
                operario => operario.Status == true)
            .ToList());
    }

    public RetornarOperario RetornarPorId(Guid id)
    {
        return _mapper.Map<RetornarOperario>(_context.Operarios
            .Where<Operario>(operario => operario.Status == true)
            .FirstOrDefault(operario => operario.Id == id));
    }

    public RetornarOperario Inserir(InserirOperario entity)
    {
        Operario operario = _mapper.Map<Operario>(entity);
        _context.Add(operario);
        _context.SaveChanges();

        return _mapper.Map<RetornarOperario>(operario);
    }

    public void Atualizar(Guid id, AtualizarOperario entity)
    {
        throw new NotImplementedException();
    }
    public bool Deletar(Guid id)
    {
        Operario? operario = _context.Operarios
            .FirstOrDefault(operario => operario.Id == id);

        if (operario is null) return false;

        operario.Status = false;
        _context.SaveChanges();
        return true;
    }
}
