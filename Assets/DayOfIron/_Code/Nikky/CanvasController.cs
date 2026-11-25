using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryCanvas;
    [SerializeField] private GameObject _hotbarPanel;

    private void Start()
    {
        if (_inventoryCanvas != null) { _inventoryCanvas.SetActive(false); }
        if (_hotbarPanel != null) { _hotbarPanel.SetActive(true); }
    }
    
    public void OpenCloseInventory()
    {
        if (_inventoryCanvas.activeSelf == true)
        {
            _inventoryCanvas.SetActive(false);
            _hotbarPanel.SetActive(true);
        }
        else
        {
            _inventoryCanvas.SetActive(true);
            _hotbarPanel.SetActive(false);
        }
    }
}
