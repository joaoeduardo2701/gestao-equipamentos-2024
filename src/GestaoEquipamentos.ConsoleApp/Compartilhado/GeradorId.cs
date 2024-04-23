namespace GestaoEquipamentos.ConsoleApp.Compartilhado;

public static class GeradorId
{
    private static int IdEquipamentos = 0;

    public static int GerarIdEquipamento()
    {
        return ++IdEquipamentos;
    }
}
