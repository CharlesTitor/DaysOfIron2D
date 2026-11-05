using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    // Total de mensajes de la conversación
    public string[] dialogos;

    // Índice del mensaje actual
    private int indiceActual = 0;

    // Referencia al sistema de quests
    public QuestManager1 questManager;

    // Función que se llama al avanzar el diálogo
    public void SiguienteMensaje()
    {
        indiceActual++;

        // Verifica si acabamos de llegar al último mensaje
        if (indiceActual >= dialogos.Length)
        {
            ConversacionTerminada();
        }
    }

    void ConversacionTerminada()
    {
        // Activa la quest
        questManager.ActivarQuestIron();

        Debug.Log("Conversación terminada");
    }
}
    
