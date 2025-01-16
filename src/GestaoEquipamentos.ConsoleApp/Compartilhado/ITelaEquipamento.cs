namespace GestaoEquipamentos.ConsoleApp.Compartilhado;

public interface ITelaEquipamento
{
    char ApresentarMenu();
    void CadastrarEquipamento();
    void EditarEquipamento();
    void ExcluirEquipamento();
    void VisualizarEquipamentos(bool exibirTitulo);
}
