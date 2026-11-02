using UnityEngine;
using UnityEngine.Serialization;

public class InventoryManagerUI : MonoBehaviour
{
    public static InventoryManagerUI Instance;

    [FormerlySerializedAs("itemSlotPrefab")]
    public GameObject ItemSlotPrefab;
    [FormerlySerializedAs("inventoryContainer")]
    public Transform InventoryContainer;

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

    public void RefreshInventoryUI()
    {
        //0. Clear existing UI elements
        foreach(Transform slot in InventoryContainer)
        {
            Destroy(slot.gameObject);
        }

        //1. Create UI elements for each item in the inventory
        foreach(Item item in InventoryManager.Instance.Inventory)
        {
            GameObject newItemSlot = Instantiate(ItemSlotPrefab, InventoryContainer);

            ItemSlotUI itemSlotUI = newItemSlot.GetComponent<ItemSlotUI>();

            itemSlotUI.ItemIconImage.sprite = item.ItemData.ItemIcon;
            itemSlotUI.ItemNameText.text = item.ItemData.ItemName;
            itemSlotUI.ItemQuantityText.text = "x" + item.ItemQuantity.ToString();
        }
    }
}
