using UnityEngine;
using UnityEngine.Serialization;
using System.Collections.Generic;

public class InventoryManagerUI : MonoBehaviour
{
    public static InventoryManagerUI Instance;

    [FormerlySerializedAs("ItemSlotPrefab")]
    [SerializeField] private GameObject _itemSlotPrefab;
    [FormerlySerializedAs("InventoryContainer")]
    [SerializeField] private Transform _inventoryContainer;

    private List<ItemSlotUI> _itemSlots = new List<ItemSlotUI>();

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
        }
    }

    private void Start()
    {
        RefreshInventoryUI();
    }
    
    private void CreateItemSlot()
    {
        GameObject newSlot=Instantiate(_itemSlotPrefab, _inventoryContainer);

        ItemSlotUI itemSlot=newSlot.GetComponent<ItemSlotUI>();

        _itemSlots.Add(itemSlot);
    }

     private void CheckSlots()
    {
        while (_itemSlots.Count < InventoryManager.Instance.Inventory.Count)
        {
            CreateItemSlot();
        }
    }

    public void UpdateItemSlot(int index, Item item)
    {
        CheckSlots();

        if (index < _itemSlots.Count)
        {
            _itemSlots[index].SetItem(item);
        }
    }


    public void RefreshInventoryUI()
    {
        if (InventoryManager.Instance == null)
        {
            return;
        }

        CheckSlots();

        for (int i = 0; i < _itemSlots.Count; i++)
        {
            if (i < InventoryManager.Instance.Inventory.Count)
            {
                _itemSlots[i].SetItem(InventoryManager.Instance.Inventory[i]);
            }
            else
            {
                _itemSlots[i].ClearSlot();
            }
        }
    }
}
