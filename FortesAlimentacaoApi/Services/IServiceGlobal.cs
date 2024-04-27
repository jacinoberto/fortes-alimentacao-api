using System.Collections.ObjectModel;

namespace FortesAlimentacaoApi.Services;

public interface IServiceGlobal<TInserir, TLeitura, TAtualizar>
    where TInserir : class
    where TLeitura : class
    where TAtualizar : class
{
    public TLeitura RetornarPorId(Guid id);
    public IEnumerable<TLeitura> RetornarTodos();
    public TLeitura Inserir(TInserir entity);
    public void Atualizar(Guid id, TAtualizar entity);
    public bool Deletar(Guid id);
}
