using UnityEngine;
using TMPro;

public class QuestManager1 : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI questTexto;
    public TextMeshProUGUI inventarioTexto;

    [Header("Items")]
    public int bombaRota = 0;

    [Header("Quest Iron")]
    public int ironActual = 0;
    public int ironNecesario = 3;

    bool questActiva = false;

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