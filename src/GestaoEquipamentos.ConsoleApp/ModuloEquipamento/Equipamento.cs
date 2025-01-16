namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamento;

public class Equipamento
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string NumeroSerie { get; set; }
    public string Fabricante { get; set; }
    public decimal PrecoAquisicao { get; set; }
    public DateTime DataFabricacao { get; set; }

    public Equipamento(string nome, string numeroSerie, string fabricante, decimal precoAquisicao, DateTime dataFabricacao)
    {
        Nome = nome;
        NumeroSerie = numeroSerie;
        Fabricante = fabricante;
        PrecoAquisicao = precoAquisicao;
        DataFabricacao = dataFabricacao;
    }
}
