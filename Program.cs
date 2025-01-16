using ProjetoTransporte;

int opcao;
Transporte t = new Transporte();
do
{
    Console.WriteLine("\nMenu de Opções:");
    Console.WriteLine("0. Finalizar");
    Console.WriteLine("1. Cadastrar veículo");
    Console.WriteLine("2. Cadastrar garagem");
    Console.WriteLine("3. Iniciar jornada");
    Console.WriteLine("4. Encerrar jornada");
    Console.WriteLine("5. Liberar viagem");
    Console.WriteLine("6. Listar veículos em garagem");
    Console.WriteLine("7. Informar quantidade de viagens");
    Console.WriteLine("8. Listar viagens realizadas");
    Console.WriteLine("9. Informar passageiros transportados");

    Console.Write("Escolha uma opção: ");
    opcao = int.Parse(Console.ReadLine());

    switch (opcao)
    {
        case 1: t.CadastrarVeiculo(); break;
        case 2: t.CadastrarGaragem(); break;
        case 3: t.IniciarJornada(); break;
        case 4: t.EncerrarJornada(); break;
        case 5: t.LiberarViagem(); break;
        case 6: t.ListarVeiculosGaragem(); break;
        case 7: t.InformarViagens(); break;
        case 8: t.ListarViagensRealizadas(); break;
        case 9: t.InformarPassageiros(); break;
    }
} while (opcao != 0);