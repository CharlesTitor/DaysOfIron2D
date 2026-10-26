using UnityEngine;
using DialogueEditor;

public class DialogueQuestGiver : MonoBehaviour
{
    [SerializeField] private Quest _quest;

    public void StartQuest()
    {
        QuestManager.Instance.StartQuest(_quest);
        Debug.Log("Quest Started");
    }
}
