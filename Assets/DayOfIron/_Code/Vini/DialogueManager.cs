using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    // Total de mensajes de la conversación
    public string[] dialogos; //CamelCase y español

    // Índice del mensaje actual
    private int indiceActual = 0; //CamelCase y español

    // Referencia al sistema de quests
    public QuestManager1 questManager;

    // Función que se llama al avanzar el diálogo
    public void SiguienteMensaje() //Español
    {
        indiceActual++;

        // Verifica si acabamos de llegar al último mensaje
        if (indiceActual >= dialogos.Length)
        {
            ConversacionTerminada(); //Español
        }
    }

    void ConversacionTerminada()
    {
        // Activa la quest
        questManager.ActivarQuestIron(); //Español

        Debug.Log("Conversación terminada");
    }
}
    
