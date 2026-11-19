using System.Collections.Generic;
using UnityEngine;

public class HotbarManager : MonoBehaviour
{
    public static HotbarManager Instance;

    [SerializeField] private GameObject _hotbarSlotPrefab;
    [SerializeField] private Transform _hotbarContainer;

    private List<HotbarSlotUI> _hotbarSlots=new List<HotbarSlotUI>();
    
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

    private void Start()
    {
        UpdateHotbar();
    }

    private void CreateHotbarSlot()
    {
        GameObject newSlot=Instantiate(_hotbarSlotPrefab, _hotbarContainer);

        HotbarSlotUI hotbarSlot=newSlot.GetComponent<HotbarSlotUI>();

        if (hotbarSlot==null)
        {
            Destroy(newSlot);
            return;
        }

        _hotbarSlots.Add(hotbarSlot);
    }

    public void UpdateHotbar()
    {
        if (InventoryManager.Instance == null)
        {
            return;
        }
        
        while (_hotbarSlots.Count<InventoryManager.Instance.Inventory.Count)
        {
            int previousCount=_hotbarSlots.Count;

            CreateHotbarSlot();

            if (_hotbarSlots.Count==previousCount)
            {
                return;
            }
        }
        for (int i=0; i<_hotbarSlots.Count; i++)
        {
            if (i<InventoryManager.Instance.Inventory.Count)
            {
                _hotbarSlots[i].gameObject.SetActive(true);

                Item item = InventoryManager.Instance.Inventory[i];

                _hotbarSlots[i].SetItem(item);
            }
            else
            {
                _hotbarSlots[i].ClearSlot();
                _hotbarSlots[i].gameObject.SetActive(false);
            }
        }
    }
}
