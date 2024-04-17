namespace GestaoEquipamentos.ConsoleApp;
static class GeradorIds
{
    private static int ContadorEquipamentosCadastrados = 0;

    public static int GeradorNovoIdEquipamento()
    {
        return ++ContadorEquipamentosCadastrados;
    }
}
