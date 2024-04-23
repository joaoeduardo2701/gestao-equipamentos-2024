using GestaoEquipamentos.ConsoleApp.Compartilhado;
using System.Reflection.Metadata.Ecma335;

namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamento;
internal class RepositorioEquipamento
{
    private Equipamento[] equipamentos = new Equipamento[100];

    public void CadastrarEquipamento(Equipamento novoEquipamento)
    {
        novoEquipamento.Id = GeradorId.GerarIdEquipamento();

        RegistrarItem(novoEquipamento);
    }

    public bool EditarEquipamento(int id, Equipamento equipamentoEditado)
    {
        equipamentoEditado.Id = id;

        for (int i = 0; i < equipamentos.Length; i++)
        {
            if (equipamentos[i] == null)
            {
                continue;
            }
            else if (equipamentos[i].Id == id)
            {
                equipamentos[i] = equipamentoEditado;
                return true;
            }
        }

        return false;
    }

    public bool ExcluirEquipamento(int equipamentoEscolhido)
    {
        for (int i = 0; i < equipamentos.Length; i++)
        {
            if (equipamentos[i] == null)
            {
                continue;
            }
            else if (equipamentos[i].Id == equipamentoEscolhido)
            {
                equipamentos[i] = null;
                return true;
            }
        }
        return false;
    }

    public Equipamento[] SelecionarEquipamento()
    {
        return equipamentos;
    }

    public bool ExisteEquipamento(int id)
    {
        for (int i = 0; i < equipamentos.Length; i++)
        {
            Equipamento e = equipamentos[i];

            if (e == null)
            {
                continue;
            }
            else if (e.Id == id)
            {
                return true;
            }
        }
        return false;
    }

    private void RegistrarItem(Equipamento equipamento)
    {
        for (int i = 0; i < equipamentos.Length; i++)
        {
            if (equipamentos[i] != null)
            {
                continue;
            }
            else
            {
                equipamentos[i] = equipamento;
                break;
            }
        }
    }
}
