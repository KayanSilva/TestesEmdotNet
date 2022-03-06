using ParkingLot.Models;

public class Program
{
    // Cria uma lista de objetos do tipo veículos, para armazenar
    // os veículos (automovéis e motos) que estão no estacionamento;
    private static Yard yard = new Yard();

    private static void Main(string[] args)
    {
        string opcao;
        do
        {
            Console.WriteLine(MostrarCabecalho());
            Console.WriteLine(MostrarMenu());
            opcao = LerOpcaoMenu();
            ProcessarOpcaoMenu(opcao);
            PressionaTecla();
            Console.Clear();// limpa a tela;
        } while (opcao != "5");
    }

    // Métodos de negócios.
    private static void MostrarVeiculosEstacionados()
    {
        Console.Clear();
        Console.WriteLine(" Veículos Estacionados");
        foreach (Vehicle v in yard.Vehicles)
        {
            // placa, proprietario, hora
            Console.WriteLine("Placa :{0}", v.Plate);
            Console.WriteLine("Proprietário :{0}", v.Owner);
            Console.WriteLine("Hora de entrada :{0:HH:mm:ss}", v.CheckIn);
            Console.WriteLine("********************************************");
        }
        if (yard.Vehicles.Count == 0)
        {
            Console.WriteLine("Não há veículos estacionados no momento...");
        }
        PressionaTecla();
    }

    private static void RegistrarSaidaVeiculo()
    {
        Console.Clear();
        Console.WriteLine("Registro de Saída de Veículos");
        Console.Write("Placa: ");
        string placa = Console.ReadLine();
        Console.WriteLine(yard.CheckOut(placa));
        PressionaTecla();
    }

    private static void RegistrarEntradaVeiculo()
    {
        Console.Clear();
        Console.WriteLine("Registro de Entrada de Veículos");
        Console.Write("Tipo de veículo (1-Carro; 2-Moto) :");
        string tipo = Console.ReadLine();
        switch (tipo)
        {
            case "1":
                RegistrarEntradaAutomovel();
                break;

            case "2":
                RegistrarEntradaMotocicleta();
                break;

            default:
                Console.WriteLine("Tipo Inválido");
                PressionaTecla();
                break;
        }
    }

    private static void RegistrarEntradaMotocicleta()
    {
        Console.WriteLine("Dados da Motocicleta");
        Vehicle moto = new Vehicle();
        moto.Type = VehicleType.Motorcycle;
        //preeencher placa,cor,hora,entrada e proprietário
        Console.Write("Digite os dados da placa (XXX-9999): ");
        try
        {
            moto.Plate = Console.ReadLine();
        }
        catch (FormatException fe)
        {
            Console.WriteLine("ocorreu um problema: {0}", fe.Message);
            Console.WriteLine("Pressione qualquer tecla para prosseguir.");
            Console.ReadKey();
            return;
        }
        Console.Write("Digite a cor da moto: ");
        moto.Color = Console.ReadLine();
        Console.Write("Digite o nome do proprietário: ");
        moto.Owner = Console.ReadLine();
        moto.CheckIn = DateTime.Now;
        moto.SpeedUp(5);
        moto.Break(5);
        yard.CheckIn(moto);
        Console.WriteLine("Motocicleta registrada com sucesso!");
        Console.ReadKey();
    }

    private static void RegistrarEntradaAutomovel()
    {
        Console.WriteLine("Dados do Automovél");
        Vehicle carro = new Vehicle();
        carro.Type = VehicleType.Car;
        //preeencher placa,cor,hora,entrada e proprietário.
        Console.Write("Digite os dados da placa (XXX-9999): ");
        try
        {
            carro.Plate = Console.ReadLine();
        }
        catch (FormatException fe)
        {
            Console.WriteLine("ocorreu um problema: {0}", fe.Message);
            PressionaTecla();
            return;
        }
        Console.Write("Digite a cor do carro: ");
        carro.Color = Console.ReadLine();
        Console.Write("Digite o nome do proprietário: ");
        carro.Owner = Console.ReadLine();
        carro.CheckIn = DateTime.Now;
        carro.SpeedUp(5);
        carro.Break(5);
        yard.CheckIn(carro);
        Console.WriteLine("Automóvel registrado com sucesso!");
    }

    // Monta a interface da aplicação.
    private static string MostrarCabecalho()
    {
        return "Controle de Estacionamento Rotativo";
    }

    private static string LerOpcaoMenu()
    {
        string opcao;
        Console.Write("Opção desejada: ");
        opcao = Console.ReadLine();
        return opcao;
    }

    private static string MostrarMenu()
    {
        string menu = "Escolha uma opção:\n" +
                        "1 - Registrar Entrada\n" +
                        "2 - Registrar Saída\n" +
                        "3 - Exibir Faturamento\n" +
                        "4 - Mostrar Veículos Estacionados\n" +
                        "5 - Sair do Programa \n";
        return menu;
    }

    private static void PressionaTecla()
    {
        Console.WriteLine("Pressione qualquer tecla para prosseguir.");
        Console.ReadKey();
    }

    private static void ProcessarOpcaoMenu(string opcao)
    {
        switch (opcao)
        {
            case "1":
                RegistrarEntradaVeiculo();
                break;

            case "2":
                RegistrarSaidaVeiculo();
                break;

            case "3":
                Console.Clear();
                Console.WriteLine(yard.MostrarFaturamento());
                break;

            case "4":
                MostrarVeiculosEstacionados();
                break;

            case "5":
                Console.WriteLine("Obrigado por utilizar o programa.");
                break;

            default:
                Console.WriteLine("Opção de menu inválida!");
                break;
        }
    }
}