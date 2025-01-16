namespace ProjetoTransporte;

public class Transporte
{
    private List<Garagem> garagens;
    private List<Veiculo> veiculos;
    private List<Viagem> viagens;
    private bool jornadaIniciada;

    public Transporte()
    {
        this.garagens = new List<Garagem>();
        this.veiculos = new List<Veiculo>();
        this.viagens = new List<Viagem>();
        this.jornadaIniciada = false;
    }

    public void CadastrarVeiculo()
    {
        Console.Write("Digite o número do veículo: ");
        int numero = int.Parse(Console.ReadLine());

        Console.Write("Digite a capacidade do veículo: ");
        int capacidade = int.Parse(Console.ReadLine());
        
        veiculos.Add(new Veiculo(numero, capacidade));
        Console.WriteLine("Veículo cadastrado com sucesso!");
    }
    
    public void CadastrarGaragem()
    {
        Console.Write("Digite o nome da garagem: ");
        string nome = Console.ReadLine();

        garagens.Add(new Garagem(nome));
        Console.WriteLine("Garagem cadastrada com sucesso!");
    }
    
    public void IniciarJornada()
    {
        if (jornadaIniciada)
        {
            Console.WriteLine("A jornada já foi iniciada.");
            return;
        }

        int index = 0;
        foreach (var veiculo in veiculos)
        {
            garagens[index % garagens.Count].Veiculos.Add(veiculo);
            index++;
        }

        jornadaIniciada = true;
        Console.WriteLine("Jornada iniciada com sucesso!");
    }
    
    public void EncerrarJornada()
    {
        foreach (var veiculo in veiculos)
        {
            veiculo.PassageirosTransportados = 0;
        }

        viagens.Clear();
        jornadaIniciada = false;
        Console.WriteLine("Jornada encerrada com sucesso!");
    }
    
    public void LiberarViagem()
    {
        Console.Write("Digite a garagem de origem: ");
        string origemNome = Console.ReadLine();

        Console.Write("Digite a garagem de destino: ");
        string destinoNome = Console.ReadLine();

        var origem = garagens.FirstOrDefault(g => g.Nome == origemNome);
        var destino = garagens.FirstOrDefault(g => g.Nome == destinoNome);

        if (origem == null || destino == null)
        {
            Console.WriteLine("Garagem inválida.");
            return;
        }

        if (origem.Veiculos.Count == 0)
        {
            Console.WriteLine("Nenhum veículo disponível na garagem de origem.");
            return;
        }

        Console.Write("Digite o número de passageiros: ");
        int passageiros = int.Parse(Console.ReadLine());

        var veiculo = origem.Veiculos.First();
        origem.Veiculos.RemoveAt(0);
        veiculo.PassageirosTransportados += passageiros;
        destino.Veiculos.Add(veiculo);

        viagens.Add(new Viagem(origem, destino, veiculo, passageiros));
        Console.WriteLine("Viagem liberada com sucesso!");
    }
    
    public void ListarVeiculosGaragem()
    {
        Console.Write("Digite o nome da garagem: ");
        string nome = Console.ReadLine();

        var garagem = garagens.FirstOrDefault(g => g.Nome == nome);

        if (garagem == null)
        {
            Console.WriteLine("Garagem não encontrada.");
            return;
        }

        Console.WriteLine($"Garagem {nome} tem {garagem.Veiculos.Count} veículo(s):");
        foreach (var veiculo in garagem.Veiculos)
        {
            Console.WriteLine($"Veículo {veiculo.Numero} - Capacidade: {veiculo.Capacidade}");
        }
    }
    
    public void InformarViagens()
    {
        Console.Write("Digite a garagem de origem: ");
        string origemNome = Console.ReadLine();

        Console.Write("Digite a garagem de destino: ");
        string destinoNome = Console.ReadLine();

        var viagens = this.viagens.Where(v => v.Origem.Nome == origemNome && v.Destino.Nome == destinoNome).ToList();

        Console.WriteLine($"Foram realizadas {viagens.Count} viagens de {origemNome} para {destinoNome}.");
    }
    
    public void InformarPassageiros()
    {
        Console.Write("Digite a garagem de origem: ");
        string origemNome = Console.ReadLine();

        Console.Write("Digite a garagem de destino: ");
        string destinoNome = Console.ReadLine();

        var totalPassageiros = viagens
            .Where(v => v.Origem.Nome == origemNome && v.Destino.Nome == destinoNome)
            .Sum(v => v.Passageiros);

        Console.WriteLine($"Foram transportados {totalPassageiros} passageiros de {origemNome} para {destinoNome}.");
    }
    
    public void ListarViagensRealizadas()
    {
        Console.WriteLine("Viagens realizadas:");
        foreach (var viagem in viagens)
        {
            Console.WriteLine($"Origem: {viagem.Origem.Nome}, Destino: {viagem.Destino.Nome}, Veículo: {viagem.Veiculo.Numero}, Passageiros: {viagem.Passageiros}");
        }
    }
}