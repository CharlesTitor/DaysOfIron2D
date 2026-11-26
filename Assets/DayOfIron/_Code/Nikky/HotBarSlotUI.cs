
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HotbarSlotUI : MonoBehaviour
{
    [Header("Item References")]
    [SerializeField] private Image _itemIcon;
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _itemQuantity;

    public void SetItem(Item item)
    {
        _itemIcon.sprite = item.ItemData.ItemIcon;
        _itemIcon.enabled = true;

        _itemName.text = item.ItemData.ItemName;
        _itemName.gameObject.SetActive(true);

        _itemQuantity.text = "x" + item.ItemQuantity.ToString();
        _itemQuantity.gameObject.SetActive(true);
    }

    public void ClearSlot()
    {
        _itemIcon.sprite = null;
        _itemIcon.enabled = false;

        _itemName.text = "";
        _itemName.gameObject.SetActive(false);

        _itemQuantity.text = "";
        _itemQuantity.gameObject.SetActive(false);
    }
}

