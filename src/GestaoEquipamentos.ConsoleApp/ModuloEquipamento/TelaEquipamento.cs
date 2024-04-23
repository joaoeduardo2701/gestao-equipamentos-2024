namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamento;
public class TelaEquipamento
{
    RepositorioEquipamento repositorio = new RepositorioEquipamento();

    public TelaEquipamento()
    {
        Equipamento equipTest = new Equipamento("Notebook", "AEX-120", "Acer", 2000.00m, DateTime.Now);

        repositorio.CadastrarEquipamento(equipTest);
    }

    public char ApresentarMenu()
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

        return operacaoEscolhida;

        Console.WriteLine("\nDigite ENTER para continuar...");
        Console.ReadKey();
    }

    public void CadastrarEquipamento()
    {
        Cabecario();
        Console.WriteLine("Cadastrando equipamento ...");
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

        repositorio.CadastrarEquipamento(equipamento);

        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("O idEquipamentoEscolhido foi cadastrado com sucesso!");
        Console.ResetColor();

        Console.Write("\nPressione ENTER para continuar...");
        Console.ReadKey();
    }

    public void EditarEquipamento()
    {
        Cabecario();

        Console.WriteLine("Editando Equipamento...");

        Console.WriteLine();

        VisualizarEquipamentos(false);

        Console.Write("\nDigite o ID do equipamento que deseja editar: ");
        int idEquipamentoEscolhido = Convert.ToInt32(Console.ReadLine());

        if (!repositorio.ExisteEquipamento(idEquipamentoEscolhido))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("O equipamento mencionado não existe!");
            Console.ResetColor();

            Console.Write("\nPressione ENTER para continuar...");
            Console.ReadKey();
            return;
        }

        // Equipamento equipamentoEncontrado = EncontrarEquipamentoPorId(idEquipamentoEscolhido);

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

        bool conseguiuEditar = repositorio.EditarEquipamento(idEquipamentoEscolhido, equipamentoEditado);

        if (!conseguiuEditar)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Houve um erro durante a edição do equipamento!");
            Console.ResetColor();

            return;
        }

        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("O equipamento foi editado com sucesso!");
        Console.ResetColor();

        Console.Write("\nPressione ENTER para continuar...");
        Console.ReadKey();
    }

    public void ExcluirEquipamento()
    {
        Cabecario();
        Console.WriteLine("Excluindo equipamento... ");
        Console.WriteLine();

        VisualizarEquipamentos(false);

        Console.WriteLine("\nDigite o id do equipamento que deseja excluir: ");
        int idEquipamentoEscolhido = Convert.ToInt32(Console.ReadLine());

        if (!repositorio.ExisteEquipamento(idEquipamentoEscolhido))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("O equipamento mencionado não existe!");
            Console.ResetColor();

            Console.Write("\nPressione ENTER para continuar...");
            Console.ReadKey();
            return;
        }

        bool conseguiuExcluir = repositorio.ExcluirEquipamento(idEquipamentoEscolhido);

        if (!conseguiuExcluir)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Houve um erro a excluir o equipamento!");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nEquipamento excluido com sucesso!");
            Console.ResetColor();
        }

        Console.Write("\nPressione ENTER para continuar...");
        Console.ReadKey();
    }

    public void VisualizarEquipamentos(bool exibirTitulo)
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

        Equipamento[] equipamentosCadastrados = repositorio.SelecionarEquipamento();

        for (int i = 0; i < equipamentosCadastrados.Length; i++)
        {
            Equipamento e = equipamentosCadastrados[i];

            if (e == null)
                continue;

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -15} | {3, -10} | {4, -10}",
                e.Id, e.Nome, e.Fabricante, e.PrecoAquisicao, e.DataFabricacao.ToShortDateString() // "17/04/2024"
            );
        }

        Console.Write("\nPressione ENTER para continuar...");
        Console.ReadKey();
    }

    public void Cabecario()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|        Gestão de Equipamentos        |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();
    }
}
