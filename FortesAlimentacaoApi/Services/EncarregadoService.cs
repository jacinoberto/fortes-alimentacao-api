using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.Encarregado;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;

namespace FortesAlimentacaoApi.Services;

public class EncarregadoService : IGlobalService<InserirEncarregado, RetornarEncarregado, AtualizarEncarregado>
{
    private readonly FortesAlimentacaoDbContext _context;
    private readonly IMapper _mapper;

    public EncarregadoService(FortesAlimentacaoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public RetornarEncarregado Inserir(InserirEncarregado entity)
    {
        Encarregado encaregado = _mapper.Map<Encarregado>(entity);
        _context.Encarregados.Add(encaregado);
        _context.SaveChanges();

        return _mapper.Map<RetornarEncarregado>(encaregado);
    }

    public RetornarEncarregado RetornarPorId(Guid id)
    {
        return _mapper.Map<RetornarEncarregado>(_context.Encarregados
            .Where<Encarregado>(encarregado => encarregado.Gestor.Status == true)
            .FirstOrDefault(encarregado => encarregado.Id == id));
    }

    public IEnumerable<RetornarEncarregado> RetornarTodos()
    {
        return _mapper.Map<IEnumerable<RetornarEncarregado>>(_context.Encarregados
            .Where<Encarregado>(encarregado => encarregado.Gestor.Status == true)
            .ToList());
    }
    public void Atualizar(Guid id, AtualizarEncarregado entity)
    {
        throw new NotImplementedException();
    }

    public bool Deletar(Guid id)
    {
        Encarregado? encarregado = _context.Encarregados
            .FirstOrDefault(encarregado => encarregado.Id == id);

        if (encarregado is not null)
        {
            encarregado.InativarPerfil();
            _context.SaveChanges();
            return true;
        }
        else return false;
    }
}
