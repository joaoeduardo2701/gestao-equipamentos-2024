namespace GestaoEquipamentos.ConsoleApp;
internal class Equipamentos
{
    public string Nome;
    public decimal PrecoAquisicao;
    public string NumeroSerie;
    public DateTime DataFabricacao;
    public string Fabricante;
    public int Id;

    public Equipamentos(string nome, decimal precoAquisicao, string numeroSerie, DateTime dataFabricacao, string fabricante)
    {
        Id = GeradorIds.GeradorNovoIdEquipamento();
        Nome = nome;
        PrecoAquisicao = precoAquisicao;
        NumeroSerie = numeroSerie;
        DataFabricacao = dataFabricacao;
        Fabricante = fabricante;
    }
}
