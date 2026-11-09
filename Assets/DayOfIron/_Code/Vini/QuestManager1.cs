using UnityEngine;
using TMPro;

public class QuestManager1 : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI questTexto; //CamelCase y español
    public TextMeshProUGUI inventarioTexto; //CamelCase y español

    [Header("Items")]
    public int bombaRota = 0; //CamelCase y español

    [Header("Quest Iron")]
    public int ironActual = 0; //CamelCase y español
    public int ironNecesario = 3; //CamelCase y español

    bool questActiva = false; //Acceso, CamelCase y español

    public void ActivarQuestIron()
    {
        // Agregar bomba rota
        bombaRota = 1;

        // Actualizar inventario
        inventarioTexto.text = "Bomba Rota x" + bombaRota;

        // Activar quest
        questActiva = true;

        // Mostrar misión
        questTexto.text = "Objetivo: Consigue 3 Iron (0/3)";
    }

    public void AgregarIron()
    {
        if (!questActiva)
            return;

        ironActual++;

        questTexto.text =
            "Objetivo: Consigue 3 Iron (" +
            ironActual + "/3)";

        if (ironActual >= ironNecesario)
        {
            questTexto.text =
                "✅ Misión completada";
        }
    }
}