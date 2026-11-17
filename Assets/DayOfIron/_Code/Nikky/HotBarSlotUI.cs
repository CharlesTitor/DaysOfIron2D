using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HotbarSlotUI : MonoBehaviour
{
    [SerializeField] private Image _itemIcon;
    [SerializeField] private TMP_Text _itemQuantity;

    public void SetItem(Item item)
    {
        _itemIcon.sprite = item.ItemData.ItemIcon;
        _itemIcon.enabled = true;

        if (_itemQuantity != null)
        {
            _itemQuantity.text="x"+item.ItemQuantity.ToString();
        }
    }

    public void ClearSlot()
    {
        _itemIcon.sprite = null;
        _itemIcon.enabled = false;

        if (_itemQuantity != null)
        {
            _itemQuantity.text="";
        }
    }
}
