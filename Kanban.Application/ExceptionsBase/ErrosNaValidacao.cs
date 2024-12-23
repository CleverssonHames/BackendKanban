namespace Kanban.API.ExceptionsBase;

public class ErrosNaValidacao : SystemException
{
    public IList<string> MensagensErro { get; set; }

    public ErrosNaValidacao(IList<string> mensagensErro)
    {
        MensagensErro = mensagensErro;
    }
}