using UnityEngine;
using TMPro;

public class DialogoNPC1 : MonoBehaviour
{
    public TextMeshProUGUI dialogoTexto;

    public string[] dialogos;

    int lineaActual = 0;

    public QuestManager1 questManager;

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

    void SiguienteDialogo()
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