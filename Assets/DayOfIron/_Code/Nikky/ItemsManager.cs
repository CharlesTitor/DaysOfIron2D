using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemsManager : MonoBehaviour
{
    public static ItemsManager Instance;

    public int _ironQuantity = 0;
    public int _brokenBombQuantity = 0;
    public int _repairedBombQuantity = 0;

    private bool _ifbombRepaired = false;

    [SerializeField] private float _messageDuration=2f;

    /*
    private void Update()
    {
        if (Keyboard.current == null)
        {
            return;
        }

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            AddIron(1);
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            AddBrokenBomb(1);
        }
    }
    */

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
    }
    
    public void AddIron(int amountOfIron)
    {
        Debug.Log("Adding Iron");
        if (amountOfIron <= 0)
        {
            return;
        }
        _ironQuantity += amountOfIron;
        Debug.Log(amountOfIron + " added");
        HotbarManager.Instance.UpdateHotbar();
    }

    public void AddBrokenBomb(int amountOfBrokenBomb)
    {
        if (amountOfBrokenBomb <= 0)
        {
            return;
        }
        _brokenBombQuantity += amountOfBrokenBomb;
        HotbarManager.Instance.UpdateHotbar();    
    }

    public bool TryRepairBomb(out string message)
    {
        if (_ifbombRepaired)
        {
            message = "Ya reparaste la bomba";
            return false;
        }

        int missingIron = 3 - _ironQuantity;
        bool ifmissingBrokenBomb = _brokenBombQuantity < 1;

        if (missingIron > 0 || ifmissingBrokenBomb)
        {
            if (missingIron > 0 && ifmissingBrokenBomb)
            {
                message = "Te falta " + missingIron + " iron y necesitas una bomba rota";
            }
            else if (missingIron > 0)
            {
                message = "Te falta " + missingIron + " iron";
            }
            else
            {
                message = "Necesitas una bomba rota";
            }

            return false;
        }

        //los quita
        _ironQuantity -= 3;
        _brokenBombQuantity -= 1;

        //agrega la bomba
        _repairedBombQuantity++;

        //ya no deja hacer mas bombas
        _ifbombRepaired = true;

        HotbarManager.Instance.UpdateHotbar();

        message = "Bomba reparada";
        new WaitForSeconds(_messageDuration);
        SceneManager.LoadScene(3);
        return true;
    }
}
