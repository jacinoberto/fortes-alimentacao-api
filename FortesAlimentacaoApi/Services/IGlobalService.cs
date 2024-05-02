using System.Collections.ObjectModel;

namespace FortesAlimentacaoApi.Services;

public interface IGlobalService<TInserir, TLeitura>
    where TInserir : class
    where TLeitura : class
{
    public Task<TLeitura> RetornarPorId(Guid id);
    public Task<IEnumerable<TLeitura>> RetornarTodos();
    public Task<TLeitura> Inserir(TInserir entity);
    //public void Atualizar(Guid id, TAtualizar entity);
    public Task<bool> Deletar(Guid id);
}
