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
}
