using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject InventoryCanvas;

    /*
    private void Start()
    {
        InventoryCanvas.SetActive(false);
    }
    */

    public void OpenCloseInventory()
    {
        if (InventoryCanvas.activeSelf == true)
        {
            InventoryCanvas.SetActive(false);
        }
        else
        {
            InventoryCanvas.SetActive(true);
        }
    }
}
