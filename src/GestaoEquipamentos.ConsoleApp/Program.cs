namespace GestaoEquipamentos.ConsoleApp;

internal class Program
{
    static Equipamento[] equipamentos = new Equipamento[100];
    static int contadorEquipamentosCadastrados = 0;

    static void Main(string[] args)
    {
        // equipamentos[contadorEquipamentosCadastrados++] = new Equipamento("Notebook", "AEX-120", "Acer", 2000.00m, DateTime.Now);

        bool opcaoSairEscolhida = false;

        while (!opcaoSairEscolhida)
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|        Gestão de Equipamentos        |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Gerência de Equipamentos");
            Console.WriteLine("2 - Controle de Chamados [Não Disponível]");
            Console.WriteLine("S - Sair");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char opcaoEscolhida = Console.ReadLine()[0];

            switch (opcaoEscolhida)
            {
                case '1': GerenciarEquipamentos(); break;
                case '2': GerenciarChamados(); break;

                default: opcaoSairEscolhida = true; break;
            }
        }

        Console.ReadLine();
    }

    static void GerenciarEquipamentos()
    {
        Cabecario();

        Console.WriteLine("1 - Cadastrar Equipamento");
        Console.WriteLine("2 - Editar Equipamento");
        Console.WriteLine("3 - Excluir Equipamento");
        Console.WriteLine("4 - Visualizar Equipamentos");

        Console.WriteLine("S - Voltar");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

        switch (operacaoEscolhida)
        {
            case '1': CadastrarEquipamento(); break;
            case '2': EditarEquipamento(); break;
            case '3': ExcluirEquipamento(); break;
            case '4': VisualizarEquipamentos(true); break;

            default: break;
        }

        Console.ReadLine();
    }

    private static void ExcluirEquipamento()
    {
        Cabecario();
        Console.WriteLine("Excluindo equipamento... ");
        Console.WriteLine();


    }

    private static void CadastrarEquipamento()
    {
        Cabecario();
        Console.WriteLine("Cadastrando equipamento...");
        Console.WriteLine();

        Console.Write("Digite o nome do equipamento: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o número de série do equipamento: ");
        string numeroSerie = Console.ReadLine();

        Console.Write("Digite o nome do fabricante do equipamento: ");
        string fabricante = Console.ReadLine();

        Console.Write("Digite o preço de aquisição do equipamento: R$ ");
        decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Digite a data de fabricação do equipamento (formato: dd-MM-aaaa): ");
        DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

        Equipamento equipamento = new Equipamento(nome, numeroSerie, fabricante, precoAquisicao, dataFabricacao);

        equipamentos[contadorEquipamentosCadastrados++] = equipamento;

        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine();

        Console.WriteLine("O equipamento foi cadastrado com sucesso!");

        Console.ResetColor();

        Console.ReadLine();
    }

    private static void Cabecario()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|        Gestão de Equipamentos        |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();
    }

    static void VisualizarEquipamentos(bool exibirTitulo)
    {

        if (exibirTitulo)
        {
            Cabecario();

            Console.WriteLine("Visualizando Equipamentos...");
        }

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -15} | {2, -15} | {3, -10} | {4, -10}",
            "Id", "Nome", "Fabricante", "Preço", "Data de Fabricação"
        );

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento e = equipamentos[i];

            if (e == null)
                continue;

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15} | {3, -10} | {4, -10}",
                e.Id, e.Nome, e.Fabricante, e.PrecoAquisicao, e.DataFabricacao.ToShortDateString() // "17/04/2024"
            );
        }

        Console.ReadLine();
        Console.WriteLine();
    }

    public static void EditarEquipamento()
    {
        Cabecario();

        Console.WriteLine("Editando Equipamento...");

        Console.WriteLine();

        VisualizarEquipamentos(false);

        Console.Write("Digite o ID do equipamento que deseja editar: ");
        int equipamentoEscolhido = Convert.ToInt32(Console.ReadLine());

        Equipamento equipamentoEncontrado = EncontrarEquipamentoPorId(equipamentoEscolhido);

        Console.WriteLine();

        Console.Write("Digite o nome do equipamento: ");
        equipamentoEncontrado.Nome = Console.ReadLine();

        Console.Write("Digite o número de série do equipamento: ");
        equipamentoEncontrado.NumeroSerie = Console.ReadLine();

        Console.Write("Digite o nome do fabricante do equipamento: ");
        equipamentoEncontrado.Fabricante = Console.ReadLine();

        Console.Write("Digite o preço de aquisição do equipamento: R$ ");
        equipamentoEncontrado.PrecoAquisicao = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Digite a data de fabricação do equipamento (formato: dd-MM-aaaa): ");
        equipamentoEncontrado.DataFabricacao = Convert.ToDateTime(Console.ReadLine());

        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine();

        Console.WriteLine("O equipamento foi editado com sucesso!");

        Console.ResetColor();

        Console.ReadLine();
    }

    public static Equipamento EncontrarEquipamentoPorId(int idEscolhido)
    {
        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento e = equipamentos[i];

            if (e == null)
                continue;

            if (e.Id == idEscolhido)
                return e;
        }

        return null;
    }

    static void GerenciarChamados()
    {

    }
}
