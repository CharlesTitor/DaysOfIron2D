using UnityEngine;
using System.Collections.Generic;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    [SerializeField] private List<QuestProgress> _activeQuests = new List<QuestProgress>();


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else { Destroy(gameObject); }
    }


    public void StartQuest(Quest quest)
    {
        QuestProgress newQuest = new QuestProgress(quest);
        _activeQuests.Add(newQuest);
    }


    public bool IsQuestActive(Quest quest)
    {
        foreach (QuestProgress questProgress in _activeQuests)
        {
            if(questProgress.Quest == quest)
            {
                return true;
            }
        }
        return false;
    }

    public void UpdateQuestObjective(ItemData item, int itemQuantity)
    {
        foreach (QuestProgress questProgress in _activeQuests)
        {
            foreach (QuestObjective objective in questProgress.Objectives)
            {
                if (objective.Type == ObjectiveType.CollectItem && objective.ItemRequired == item)
                {
                    objective.CurrentAmount += itemQuantity;
                    Debug.Log($"You have {objective.CurrentAmount} of {objective.RequiredAmount}");
                    if (questProgress.IsCompleted) { Debug.Log("Quest completed"); }
                }
            }
        }
    }
}
