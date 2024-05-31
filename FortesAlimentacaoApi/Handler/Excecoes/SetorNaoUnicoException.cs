namespace FortesAlimentacaoApi.Handler.Excecoes;

public class SetorNaoUnicoException : Exception
{
    public SetorNaoUnicoException() : base() {}
    public SetorNaoUnicoException(string menssagem) : base(menssagem) {}
    public SetorNaoUnicoException(string menssagem, Exception inner) : base(menssagem, inner) {}
}
