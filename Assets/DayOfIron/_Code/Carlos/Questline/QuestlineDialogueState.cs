using DialogueEditor;
using UnityEngine;

public class QuestlineDialogueState : MonoBehaviour , IInteractable
{

    [SerializeField] private float _interactionDistance = 1f;

    [SerializeField] private NPCConversation _dialogueStartQuest;
    [SerializeField] private NPCConversation _dialogueIsQuestStarted;
    [SerializeField] private NPCConversation _dialogueCompletingQuest;
    [SerializeField] private NPCConversation _dialogueIsQuestCompleted;

    [SerializeField] private ItemData _iron;
    [SerializeField] private ItemData _brokenBomb;
    [SerializeField] private ItemData _repairedBomb;


    public bool CanInteract(IInteractor interactor)
    {
        GameObject gameObjectInetactor = (interactor as Component)?.gameObject;
        return Vector3.Distance(gameObjectInetactor.transform.position, this.transform.position) < _interactionDistance;
    }

    public void Interact(IInteractor interactor)
    {
        if (!_iron) { Debug.Log("no existe iron"); }
        if (!_brokenBomb) { Debug.Log("no existe bomba"); }
        if (!InventoryManager.Instance.HasItem(_iron, 1) && !InventoryManager.Instance.HasItem(_brokenBomb, 1))
        {
            ConversationManager.Instance.StartConversation(_dialogueStartQuest);
        }
        else if (!InventoryManager.Instance.HasItem(_iron, 1) && InventoryManager.Instance.HasItem(_brokenBomb, 1))
        {
            ConversationManager.Instance.StartConversation(_dialogueIsQuestStarted);
        }
        else if (InventoryManager.Instance.HasItem(_iron, 3) && InventoryManager.Instance.HasItem(_brokenBomb, 1))
        {
            ConversationManager.Instance.StartConversation(_dialogueCompletingQuest);
        }
        else if (InventoryManager.Instance.HasItem(_repairedBomb, 1))
        {
            ConversationManager.Instance.StartConversation(_dialogueIsQuestCompleted);
        }
    }

}
