namespace KanBan.Domain.Models;

public class Quadro
{
    public Guid Id { get; init; }
    public string Nome { get; private set; }

    public Quadro(string nome)
    {
        Nome = nome;
        Id = Guid.NewGuid();
    }

    public void AtualizarNome(string nome)
    {
        Nome = nome;
    }
}