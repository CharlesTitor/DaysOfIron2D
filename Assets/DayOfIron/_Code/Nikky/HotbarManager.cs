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

    private int _ironQuantity = 0;
    private int _brokenBombQuantity = 0;
    private int _repairedBombQuantity = 0;

    private bool _ifbombRepaired = false;

    [SerializeField] private float _messageDuration=2f;


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

    // SOLO TEMPORAL PARA PROBAR SI SIRVE
    public void AddIron(int amountOfIron)
    {
        Debug.Log("Adding Iron");
        if (amountOfIron <= 0)
        {
            return;
        }
        _ironQuantity += amountOfIron;
        Debug.Log(amountOfIron + " added");
        UpdateHotbar();
    }

    public void AddBrokenBomb(int amountOfBrokenBomb)
    {
        if (amountOfBrokenBomb <= 0)
        {
            return;
        }
        _brokenBombQuantity += amountOfBrokenBomb;
        UpdateHotbar();
    }

    //Cambia el 'x0'
    public void UpdateHotbar()
    {
        Debug.Log("Updating Hotbar");
        //IGUAL
        _ironQuantityText.text = "x" + _ironQuantity;

        _brokenBombQuantityText.text = "x" + _brokenBombQuantity;
        _repairedBombQuantityText.text = "x" + _repairedBombQuantity;
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

        UpdateHotbar();

        message = "Bomba reparada";
        new WaitForSeconds(_messageDuration);
        SceneManager.LoadScene(3);
        return true;
    }
}
