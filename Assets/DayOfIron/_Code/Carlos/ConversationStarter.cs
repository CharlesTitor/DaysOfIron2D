using DialogueEditor;
using UnityEngine;

public class ConversationStarter : MonoBehaviour , IInteractable
{
    [SerializeField] private NPCConversation _npcConversation;
    [SerializeField] private float _interactionDistance = 1f;
    [SerializeField] private EventChannelSO _interruptMoveChannel;

    public bool CanInteract(IInteractor interactor)
    {
        GameObject gameObjectInetactor = (interactor as Component)?.gameObject;
        return Vector3.Distance(gameObjectInetactor.transform.position, this.transform.position) < _interactionDistance;
    }

    public void Interact(IInteractor interactor)
    {
        _interruptMoveChannel.EventChannel?.Invoke();
        ConversationManager.Instance.StartConversation(_npcConversation);
    }
}