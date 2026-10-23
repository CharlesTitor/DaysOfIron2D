using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    [FormerlySerializedAs("inventory")]
    public List<Item> Inventory = new List<Item>();

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

        GetComponent<HotbarManager>().RefreshHotbar();
        GetComponent<InventoryManagerUI>().RefreshInventoryUI();
    }

    public void AddItem(ItemData typeOfItem, int cuantityOfItem)
    {
        foreach (Item item in Inventory)
        {
            if(item.ItemData.ItemName == typeOfItem.ItemName)
            {
                item.ItemQuantity += cuantityOfItem;
                QuestManager.Instance.UpdateQuestObjective(typeOfItem, cuantityOfItem);
                return;
            }
        }

        Inventory.Add(new Item { ItemData = typeOfItem, ItemQuantity = cuantityOfItem });
        QuestManager.Instance.UpdateQuestObjective(typeOfItem, cuantityOfItem);
    }
}
