using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    [FormerlySerializedAs("inventory")]
    public List<Item> Inventory = new List<Item>();

    public bool HasRepairedBomb {get; private set;}

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

    private void UpdateHotbar()
    {
        if (HotbarManager.Instance != null)
        {
            HotbarManager.Instance.UpdateHotbar();
        }
    }
    public void MarkBombRepaired()
    {
        HasRepairedBomb=true;
    }

    public void AddItem(ItemData typeOfItem, int cuantityOfItem)
    {
        if (typeOfItem==null || cuantityOfItem<= 0)
        {
            return;
        }

        //Si existe, le agrega
        for (int i=0; i<Inventory.Count; i++)
        {
            if (Inventory[i].ItemData ==typeOfItem)
            {
                Inventory[i].ItemQuantity+=cuantityOfItem;

                UpdateUI(i);
                UpdateHotbar();

                if (QuestManager.Instance!=null)
                {
                    QuestManager.Instance.UpdateQuestObjective(typeOfItem, cuantityOfItem);
                }

                return;
            }
        }

        //Si no existe, lo crea
        Item newItem= new Item();

        newItem.ItemData= typeOfItem;
        newItem.ItemQuantity= cuantityOfItem;

        Inventory.Add(newItem);

        RefreshUI();
        UpdateHotbar();

        if (QuestManager.Instance!=null)
        {
            QuestManager.Instance.UpdateQuestObjective(typeOfItem, cuantityOfItem);
        }
    }

    public bool RemoveItem(ItemData typeOfItem, int cuantityOfItem)
    {
        if (typeOfItem==null || cuantityOfItem<= 0)
        {
            return false;
        }

        for (int i=0; i<Inventory.Count; i++)
        {
            if (Inventory[i].ItemData==typeOfItem)
            {
                if (Inventory[i].ItemQuantity<cuantityOfItem)
                {
                    return false;
                }

                Inventory[i].ItemQuantity-=cuantityOfItem;

                if (Inventory[i].ItemQuantity<=0)
                {
                    Inventory.RemoveAt(i);
                    RefreshUI();
                }
                else
                {
                    UpdateUI(i);
                }
                
                UpdateHotbar();

                return true;
            }
        }

        return false;
    }

    public int GetQuantity(ItemData typeOfItem)
    {
        for (int i=0; i<Inventory.Count; i++)
        {
            if (Inventory[i].ItemData ==typeOfItem)
            {
                return Inventory[i].ItemQuantity;
            }
        }

        return 0;
    }

    public bool HasItem(ItemData typeOfItem, int cuantityOfItem)
    {
        return GetQuantity(typeOfItem)>=cuantityOfItem;
    }

    public bool DoesNotHasItem(ItemData typeOfItem)
    {
        return GetQuantity(typeOfItem) <= 0;
    }

    private void UpdateUI(int index)
    {
        if (InventoryManagerUI.Instance!=null)
        {
            InventoryManagerUI.Instance.UpdateItemSlot(index, Inventory[index]);
        }
    }

    private void RefreshUI()
    {
        if (InventoryManagerUI.Instance != null)
        {
            InventoryManagerUI.Instance.RefreshInventoryUI();
        }
    }
}
