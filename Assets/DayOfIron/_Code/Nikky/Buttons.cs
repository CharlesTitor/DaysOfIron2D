using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject InventoryCanvas;

    private void Start()
    {
        InventoryCanvas.SetActive(false);
    }

    public void GoToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

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
