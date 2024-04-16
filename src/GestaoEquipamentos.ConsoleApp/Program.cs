using System.Runtime.CompilerServices;

namespace GestaoEquipamentos.ConsoleApp;

internal class Program
{
    static Equipamentos[] equipamentos = new Equipamentos[10];

    static void Main(string[] args)
    {
        char opcao = 'n';
        double precoAquisicao;
        string nome, numeroSerie, dataFabricacao, fabricante;

        do
        {
            Console.Clear();
            Console.WriteLine("-- Gestão de equipamentos --");
            Console.WriteLine();
            Console.WriteLine("1 - Cadastro de equipamentos ");
            Console.WriteLine("2 - Controle de chamados ");
            Console.WriteLine("3 - Sair");
            Console.Write("-> ");

            opcao = char.Parse(Console.ReadLine());

            Console.Clear();

            switch (opcao)
            {
                case '1':
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
                        case '1':
                            Console.WriteLine("-- Inserir um novo equipamentos --");
                            Console.WriteLine();

                            Console.Write("Nome do equipamento: ");
                            nome = Console.ReadLine();

                            Console.Write("Preço de aquisição: ");
                            precoAquisicao = double.Parse(Console.ReadLine());

                            Console.Write("Número de série: ");
                            numeroSerie = Console.ReadLine();

                            Console.Write("Data de fabricação: ");
                            dataFabricacao = Console.ReadLine();

                            Console.Write("Fabricante: ");
                            fabricante = Console.ReadLine();

                            Equipamentos equipamento1 = new Equipamentos(nome, precoAquisicao, numeroSerie, dataFabricacao, fabricante);

                            equipamentos[0] = equipamento1;

                            break;
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
                            Console.WriteLine("-- Inserir um novo equipamento --");
                            Console.WriteLine();

                            break;
                        default:
                            MensagemOpcaoInvalida();
                            break;
                    }
                    break;
                case '2':
                    Console.WriteLine("-- Controle de chamados --");
                    Console.WriteLine();
                    break;
                case '3':
                    Console.WriteLine("Encerrando programa...");
                    break;
                default:
                    MensagemOpcaoInvalida();
                    break;
            }

            Console.WriteLine("Digite enter para continuar...");
            Console.ReadKey();

        } while (opcao != '3');
    }

    static void MensagemOpcaoInvalida()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Por favor insira uma opção válida!!!");
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    static Equipamentos BuscarConta(int indiceParaRetornar)
    {
        for (int i = 0; i < equipamentos.Length; i++) 
        { 
            if (equipamentos[i] == null)
                continue;

                return equipamentos[indiceParaRetornar];
        }

        return null;
    }
}
