
using System.Collections;
using TMPro;
using UnityEngine;

public class Anvil : MonoBehaviour, IInteractable
{
    [SerializeField] private TMP_Text _messageText;
    [SerializeField] private float _messageDuration=2f;

    private Coroutine _messageCoroutine;

    public bool CanInteract(IInteractor interactor)
    {
        return HotbarManager.Instance!=null;
    }

    public void Interact(IInteractor interactor)
    {
        bool ifRepaired=ItemsManager.Instance.TryRepairBomb(out string message);

        ShowMessage(message);
    }

    private void ShowMessage(string message)
    {
        if (_messageCoroutine!=null)
        {
            StopCoroutine(_messageCoroutine);
        }
        _messageText.text = message;
        _messageText.gameObject.SetActive(true);

        _messageCoroutine = StartCoroutine(HideMessage());
    }

    private IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(_messageDuration);

        _messageText.gameObject.SetActive(false);
        _messageCoroutine = null;
    }
}
