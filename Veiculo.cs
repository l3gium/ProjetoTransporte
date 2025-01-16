namespace ProjetoTransporte;

public class Veiculo
{
    private int numero;
    private int capacidade;
    private int passageirosTransportados;
    
    public int Numero { get => numero; set => numero = value; }
    public int Capacidade { get => capacidade; set => capacidade = value; }
    public int PassageirosTransportados { get => passageirosTransportados; set => passageirosTransportados = value; }

    public Veiculo(int numero, int capacidade)
    {
        this.numero = numero;
        this.capacidade = capacidade;   
    }
}