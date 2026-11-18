using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class HotbarManager : MonoBehaviour
{
    public static HotbarManager Instance;

    [SerializeField] private TMP_Text _ironQuantityText;
    [SerializeField] private TMP_Text _brokenBombQuantityText;
    [SerializeField] private TMP_Text _repairedBombQuantityText;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        UpdateHotbar();
    }

    //Cambia el 'x0'
    public void UpdateHotbar()
    {
        Debug.Log("Updating Hotbar");
        //IGUAL
        _ironQuantityText.text = "x" + ItemsManager.Instance._ironQuantity;

        _brokenBombQuantityText.text = "x" + ItemsManager.Instance._brokenBombQuantity;
        _repairedBombQuantityText.text = "x" + ItemsManager.Instance._repairedBombQuantity;
    }
}
