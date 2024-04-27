using System.Collections.ObjectModel;

namespace FortesAlimentacaoApi.Services;

public interface IServiceGlobal<TInserir, TLeitura, TAtualizar>
    where TInserir : class
    where TLeitura : class
    where TAtualizar : class
{
    public TLeitura GeteById(Guid id);
    public Collection<TLeitura> GetAll();
    public TLeitura Insert(TInserir entity);
    public void Update(Guid id, TAtualizar entity);
    public void Delete(Guid id);
}
