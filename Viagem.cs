namespace ProjetoTransporte;

public class Viagem
{
    private Garagem origem;
    private Garagem destino;
    private Veiculo veiculo;
    private int numPassageiros;
    
    
    public Garagem Origem { get => origem; set => origem = value; }
    public Garagem Destino { get => destino; set => destino = value; }
    public Veiculo Veiculo { get => veiculo; set => veiculo = value; }  
    public int Passageiros { get => numPassageiros; set => numPassageiros = value; }

    public Viagem(Garagem origem, Garagem destino, Veiculo veiculo, int numPassageiros)
    {
        this.origem = origem;
        this.destino = destino;
        this.veiculo = veiculo;
        this.numPassageiros = numPassageiros;
    }
}