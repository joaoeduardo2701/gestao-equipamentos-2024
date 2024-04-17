namespace GestaoEquipamentos.ConsoleApp;

internal class Program
{
    static Equipamentos[] equipamentos = new Equipamentos[100];
    static int contadorEquipamentosCadastrados = 0;

    static void Main(string[] args)
    {


        while (true) 
        {
            Console.Clear();

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("|          Gestão de equipamentos        |");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("1 - Cadastro de equipamentos ");
            Console.WriteLine("2 - Controle de chamados [Não Disponível]");
            Console.WriteLine("3 - Sair");
                
            Console.Write("-> ");

            char opcao = char.Parse(Console.ReadLine());

            Console.Clear();

            switch (opcao)
            {
                case '1':
                    GerenciamentoEquipamentos();
                    break;
                case '2':
                    Console.WriteLine("-- Controle de chamados --");
                    Console.WriteLine();
                    break;
                case '3':
                    Console.WriteLine("Encerrando programa...");
                    return;
                default:
                    MensagemOpcaoInvalida();
                    break;
            }

            Console.WriteLine("Digite enter para continuar...");
            Console.ReadKey();

        } 
    }

    private static void GerenciamentoEquipamentos()
    {
        char opcaoCadastro;
        Console.WriteLine("-- Cadastro de equipamentos --");
        Console.WriteLine();

        Console.WriteLine("1 - Inserir um novo equipamentos");
        Console.WriteLine("2 - Visualizar equipamentos");
        Console.WriteLine("3 - Editar equipamentos");
        Console.WriteLine("4 - Excluir equipamentos");
        Console.WriteLine("5 - Sair");
        Console.Write("-> ");

        opcaoCadastro = char.Parse(Console.ReadLine());

        switch (opcaoCadastro)
        {
            case '1': CadastrarEquipamento(); break;
            case '2':
                Console.WriteLine("-- Visualizar equipamentos --");
                Console.WriteLine();

                break;
            case '3':
                Console.WriteLine("-- Editar equipamentos --");
                Console.WriteLine();

                break;
            case '4':
                Console.WriteLine("-- Excluir equipamentos --");
                Console.WriteLine();

                break;
            case '5':
                Console.WriteLine("Voltando para o menu...");
                Console.WriteLine();

                break;
            default:
                MensagemOpcaoInvalida();
                break;
        }
    }

    private static void CadastrarEquipamento()
    {
        Console.WriteLine("-- Inserir um novo equipamentos --");
        Console.WriteLine();

        Console.Write("Nome do equipamento: ");
        string nome = Console.ReadLine();

        Console.Write("Preço de aquisição: ");
        decimal precoAquisicao = decimal.Parse(Console.ReadLine());

        Console.Write("Número de série: ");
        string numeroSerie = Console.ReadLine();

        Console.Write("Data de fabricação: ");
        DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

        Console.Write("Fabricante: ");
        string fabricante = Console.ReadLine();

        Equipamentos equipamento = new Equipamentos(nome, precoAquisicao, numeroSerie, dataFabricacao, fabricante);

        equipamentos[contadorEquipamentosCadastrados++] = equipamento;
    }

    static void MensagemOpcaoInvalida()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Por favor insira uma opção válida!!!");
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    static Equipamentos BuscarConta(int numeroConta)
    {
        for (int i = 0; i < equipamentos.Length; i++) 
        { 
            if (equipamentos[i] == null)
                continue;

            if (equipamentos[i].Id == numeroConta)
                return equipamentos[i];
        }

        return null;
    }
}
