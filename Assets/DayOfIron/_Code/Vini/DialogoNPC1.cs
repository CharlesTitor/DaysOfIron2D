using UnityEngine;
using TMPro;

public class DialogoNPC1 : MonoBehaviour
{
    public TextMeshProUGUI dialogoTexto; //CamelCase y español

    public string[] dialogos; //CamelCase y español

    int lineaActual = 0; //CamelCase y español

    public QuestManager1 questManager; //CamelCase

    void Start()
    {
        dialogoTexto.text = dialogos[0];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SiguienteDialogo();
        }
    }

    void SiguienteDialogo() // español
    {
        lineaActual++;

        if (lineaActual < dialogos.Length)
        {
            dialogoTexto.text =
                dialogos[lineaActual];
        }
        else
        {
            FinDialogo();
        }
    }

    void FinDialogo()
    {
        dialogoTexto.text = "";

        questManager.ActivarQuestIron();
    }
}