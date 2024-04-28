using AutoMapper;
using FortesAlimentacaoApi.Database.Dtos.ControleData;
using FortesAlimentacaoApi.Database.Models;
using FortesAlimentacaoApi.Infra.Context;

namespace FortesAlimentacaoApi.Services;

public class ControleDataService : IGlobalService<InserirControleData, RetornarControleData, AtualizarControleData>
{
    private readonly FortesAlimentacaoDbContext _context;
    private readonly IMapper _mapper;

    public ControleDataService(FortesAlimentacaoDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public RetornarControleData Inserir(InserirControleData entity)
    {
        ControleData controleData = _mapper.Map<ControleData>(entity);
        _context.ControleDatas.Add(controleData);
        _context.SaveChanges();

        return _mapper.Map<RetornarControleData>(controleData);
    }

    public RetornarControleData RetornarPorId(Guid id)
    {
        return _mapper.Map<RetornarControleData>(_context.ControleDatas
            .FirstOrDefault(controle => controle.Id == id));
    }

    public IEnumerable<RetornarControleData> RetornarTodos()
    {
        return _mapper.Map<IEnumerable<RetornarControleData>>(
            _context.ControleDatas.ToList());
    }
    public void Atualizar(Guid id, AtualizarControleData entity)
    {
        throw new NotImplementedException();
    }

    public bool Deletar(Guid id)
    {
        throw new NotImplementedException();
    }
}
