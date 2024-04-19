namespace GestaoEquipamentos.ConsoleApp;

internal class Program
{
    static Equipamento[] equipamentos = new Equipamento[100];
    static int contadorEquipamentosCadastrados = 0;

    static void Main(string[] args)
    {
        //Equipamento equipTest = new Equipamento("Notebook", "AEX-120", "Acer", 2000.00m, DateTime.Now);
        //equipTest.Id = GeradorId.GerarIdEquipamento();

        //equipamentos[contadorEquipamentosCadastrados] = equipTest;

        bool opcaoSairEscolhida = false;

        while (!opcaoSairEscolhida)
        {
            Cabecario();

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
                case 'S':
                    Console.WriteLine("Saindo do programa");
                    opcaoSairEscolhida = true;
                    break;

                default: 
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Por favor insira uma opção válida!!!");
                    Console.ResetColor();

                    Console.WriteLine("Digite qualquer tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }
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

        Console.WriteLine("\nDigite ENTER para continuar...");
        Console.ReadKey();
    }

    private static void ExcluirEquipamento()
    {
        Cabecario();
        Console.WriteLine("Excluindo equipamento... ");
        Console.WriteLine();

        VisualizarEquipamentos(false);

        Console.WriteLine("\nDigite o id do equipamento que deseja excluir: ");
        int equipamento = Convert.ToInt32(Console.ReadLine());

        if (!EquipamentoExiste(equipamento))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("O equipamento mencionado não existe!");
            Console.ResetColor();
            return;
        }
        
        for (int i = 0; i < equipamentos.Length; i++)
        {
            if (equipamentos[i] == null)
            {
                continue;
            }
            else if (equipamentos[i].Id == equipamento) 
            {
                equipamentos[i] = null;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nEquipamento excluido com sucesso!");
                Console.ResetColor();
            }
        }
    }

    public static bool EquipamentoExiste(int id)
    {
        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento e = equipamentos[i];

            if(e == null)
            {
                continue;
            }
            else if (e.Id == id)
            {
                return true;
            }
        }
        return false;
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
        equipamento.Id = GeradorId.GerarIdEquipamento();

        equipamentos[contadorEquipamentosCadastrados++] = equipamento;

        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine();

        Console.WriteLine("O equipamento foi cadastrado com sucesso!");

        Console.ResetColor();
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
            "{0, -10} | {1, -20} | {2, -15} | {3, -10} | {4, -10}",
            "Id", "Nome", "Fabricante", "Preço", "Data de Fabricação"
        );

        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento e = equipamentos[i];

            if (e == null)
                continue;

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -10} | {4, -10}",
                e.Id, e.Nome, e.Fabricante, e.PrecoAquisicao, e.DataFabricacao.ToShortDateString() // "17/04/2024"
            );
        }
    }

    public static void EditarEquipamento()
    {
        Cabecario();

        Console.WriteLine("Editando Equipamento...");

        Console.WriteLine();

        VisualizarEquipamentos(false);

        Console.Write("\nDigite o ID do equipamento que deseja editar: ");
        int idEquipamentoEscolhido = Convert.ToInt32(Console.ReadLine());

        if (!EquipamentoExiste(idEquipamentoEscolhido))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("O equipamento mencionado não existe!");
            Console.ResetColor();
            return;
        }

        Equipamento equipamentoEncontrado = EncontrarEquipamentoPorId(idEquipamentoEscolhido);

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

        Equipamento equipamentoEditado = new Equipamento(nome, numeroSerie, fabricante, precoAquisicao, dataFabricacao);

        equipamentoEditado.Id = idEquipamentoEscolhido;

        for (int i = 0; i < equipamentos.Length; i++)
        {
            if (equipamentos[i] == null)
            {
                continue;
            }
            else if (equipamentos[i].Id == idEquipamentoEscolhido)
            {
                equipamentos[i] = equipamentoEditado;
                break;
            }
        }

        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("O equipamento foi editado com sucesso!");
        Console.ResetColor();
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
