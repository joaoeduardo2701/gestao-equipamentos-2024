using GestaoEquipamentos.ConsoleApp.Apresentacao;
using GestaoEquipamentos.ConsoleApp.Dominio;

namespace GestaoEquipamentos.ConsoleApp;

public class Program
{
    static void Main(string[] args)
    {
        TelaEquipamento telaEquipamento = new TelaEquipamento();

        //Equipamento equipTest = new Equipamento("Notebook", "AEX-120", "Acer", 2000.00m, DateTime.Now);
        //equipTest.Id = GeradorId.GerarIdEquipamento();
        //equipamentos[contadorEquipamentosCadastrados] = equipTest;

        bool opcaoSairEscolhida = false;

        while (!opcaoSairEscolhida)
        {
            char opcaoEscolhida = ApresentarMenuPrincipal();

            switch (opcaoEscolhida)
            {
                case '1': 
                    char operacaoEscolhida = telaEquipamento.ApresentarMenu(); 

                    if (operacaoEscolhida == 's' || operacaoEscolhida == 'S')
                        break;
                    else if (operacaoEscolhida == '1')
                    {
                        telaEquipamento.CadastrarEquipamento();
                    }
                    else if (operacaoEscolhida == '2')
                    {
                        telaEquipamento.EditarEquipamento();
                    }
                    else if (operacaoEscolhida == '3')
                    {
                        telaEquipamento.ExcluirEquipamento();
                    }
                    else if (operacaoEscolhida == '4')
                    {
                        telaEquipamento.VisualizarEquipamentos(true);
                    }
                    break;
                case '2': Console.WriteLine("Gerenciar chamados"); ; break;
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

    private static char ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|        Gestão de Equipamentos        |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Gerência de equipamentos");
        Console.WriteLine("2 - Controle de chamados [Não disponível]");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

        Console.Clear();

        return operacaoEscolhida;
    }
}
