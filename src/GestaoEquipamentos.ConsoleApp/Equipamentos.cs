namespace GestaoEquipamentos.ConsoleApp;
internal class Equipamentos
{
    public string Nome;
    public double PrecoAquisicao;
    public string NumeroSerie;
    public string DataFabricacao;
    public string Fabricante;

    public Equipamentos(string nome, double precoAquisicao, string numeroSerie, string dataFabricacao, string fabricante)
    {
        Nome = nome;
        PrecoAquisicao = precoAquisicao;
        NumeroSerie = numeroSerie;
        DataFabricacao = dataFabricacao;
        Fabricante = fabricante;
    }


}
