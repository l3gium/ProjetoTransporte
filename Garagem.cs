namespace ProjetoTransporte;

public class Garagem
{
    private string nome;
    private List<Veiculo> veiculos;
    
    public string Nome { get => nome; set => nome = value; }

    public List<Veiculo> Veiculos { get => veiculos; set => veiculos = value; }

    public Garagem(string nome)
    {
        this.nome = nome;
        this.veiculos = new List<Veiculo>();
    }
}