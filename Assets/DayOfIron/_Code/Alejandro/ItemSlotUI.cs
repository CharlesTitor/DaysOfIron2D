using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class ItemSlotUI : MonoBehaviour
{
    [FormerlySerializedAs("itemIconImage")]
    public Image ItemIconImage;
    [FormerlySerializedAs("itemNameText")]
    public TMP_Text ItemNameText;
    [FormerlySerializedAs("itemQuantityText")]
    public TMP_Text ItemQuantityText;

    public void SetItem(Item item)
    {
        ItemIconImage.sprite = item.ItemData.ItemIcon;
        ItemIconImage.enabled = true;

        ItemNameText.text = item.ItemData.ItemName;
        ItemQuantityText.text = "x" + item.ItemQuantity.ToString();
    }

    public void ClearSlot()
    {
        ItemIconImage.sprite = null;
        ItemIconImage.enabled = false;

        ItemNameText.text = "";
        ItemQuantityText.text = "";
    }
}
