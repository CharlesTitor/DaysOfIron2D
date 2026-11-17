using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Anvil : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemData _ironItemData;
    [SerializeField] private ItemData _brokenBombItemData;
    [SerializeField] private ItemData _repairedBombItemData;
    
    [SerializeField] private TMP_Text _messageText;
    [SerializeField] private float _messageDuration=2f;
    [SerializeField] private GameObject _bubbleImage;

    private Coroutine _messageCoroutine;
    [SerializeField] private int _sceneToLoad = 3;


    public bool CanInteract(IInteractor interactor)
    {
        return HotbarManager.Instance!=null;
    }

    public void Interact(IInteractor interactor)
    {
        if (InventoryManager.Instance.HasRepairedBomb)
        {
            ShowMessage("Ya reparaste la bomba");
            return;
        }

        int ironQuantity= InventoryManager.Instance.GetQuantity(_ironItemData);
        int brokenBombQuantity= InventoryManager.Instance.GetQuantity(_brokenBombItemData);

        int missingIron=3-ironQuantity;

        if (missingIron>0 || brokenBombQuantity<1)
        {
            if (missingIron>0 && brokenBombQuantity<1)
            {
                ShowMessage("Te falta "+missingIron+" iron y necesitas una bomba rota");
            }
            else if (missingIron>0)
            {
                ShowMessage("Te falta "+missingIron+" iron");
            }
            else
            {
                ShowMessage("Necesitas una bomba rota");
            }

            return;
        }

        InventoryManager.Instance.RemoveItem(_ironItemData, 3);
        InventoryManager.Instance.RemoveItem(_brokenBombItemData, 1);

        InventoryManager.Instance.AddItem(_repairedBombItemData, 1);

        InventoryManager.Instance.MarkBombRepaired();

        ShowMessage("Bomba reparada",true);
    }

    private void ShowMessage(string message, bool loadScene = false)
    {
        if (_messageCoroutine!=null)
        {
            StopCoroutine(_messageCoroutine);
        }
        _messageText.text = message;
        _messageText.gameObject.SetActive(true);
        _bubbleImage.SetActive(true);

        _messageCoroutine = StartCoroutine(HideMessage(loadScene));
    }

    private IEnumerator HideMessage(bool loadScene)
    {
        yield return new WaitForSeconds(_messageDuration);

        _messageText.gameObject.SetActive(false);
        _bubbleImage.SetActive(false);
        _messageCoroutine = null;

        if (loadScene)
        {
            SceneManager.LoadScene(_sceneToLoad);
        }
    }
}
