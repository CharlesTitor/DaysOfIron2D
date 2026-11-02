using UnityEngine;
using UnityEngine.Serialization;
using System.Collections.Generic;

public enum ObjectiveType
{
    CollectItem,
    DefeatEnemy,
    ReachLocation,
    TalkToNPC,
    Custom
}

[System.Serializable]
public class QuestObjective
{

    public string ObjectiveID;
    public ItemData ItemRequired;
    [FormerlySerializedAs("description")]
    public string Description;
    [FormerlySerializedAs("type")]
    public ObjectiveType Type;
    [FormerlySerializedAs("requiredAmount")]
    public int RequiredAmount;
    [FormerlySerializedAs("currentAmount")]
    public int CurrentAmount;

    public bool IsCompleted => CurrentAmount >= RequiredAmount;
}

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quests/Quest")]
public class Quest : ScriptableObject
{
    [FormerlySerializedAs("questID")]
    public string QuestID;
    [FormerlySerializedAs("questName")]
    public string QuestName;
    [TextArea]
    [FormerlySerializedAs("description")]
    public string Description;
    [FormerlySerializedAs("objectives")]
    public List<QuestObjective> Objectives = new List<QuestObjective>();

    private void OnValidate()
    {
        if (string.IsNullOrEmpty(QuestID))
        {
            QuestID = QuestName + "_" + System.Guid.NewGuid().ToString().Substring(0, 8);
        }
    }
}

[System.Serializable]
public class QuestProgress
{
    [FormerlySerializedAs("quest")]
    public Quest Quest;
    [FormerlySerializedAs("objectives")]
    public List<QuestObjective> Objectives;

    public QuestProgress(Quest quest)
    {
        this.Quest = quest;
        this.Objectives = new List<QuestObjective>();

        foreach (QuestObjective objective in quest.Objectives)
        {
            Objectives.Add(new QuestObjective
            {
                ObjectiveID = objective.ObjectiveID,
                ItemRequired = objective.ItemRequired,
                Description = objective.Description,
                Type = objective.Type,
                RequiredAmount = objective.RequiredAmount,
                CurrentAmount = 0
            });
        }
    }

    public bool IsCompleted => Objectives.TrueForAll(o => o.IsCompleted);
    public string QuestID => Quest.QuestID;
}