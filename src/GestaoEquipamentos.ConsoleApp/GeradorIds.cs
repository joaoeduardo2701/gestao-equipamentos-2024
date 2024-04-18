namespace GestaoEquipamentos.ConsoleApp;

public static class GeradorId
{
    private static int IdEquipamentos = 0;

    public static int GerarIdEquipamento()
    {
        return ++IdEquipamentos;
    }
}