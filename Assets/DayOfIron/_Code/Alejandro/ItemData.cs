using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ItemData", menuName = "Inventory/New Item")]


public class ItemData : ScriptableObject
{
    [FormerlySerializedAs("itemName")]
    public string ItemName;
    [FormerlySerializedAs("itemIcon")]
    public Sprite ItemIcon;
    [FormerlySerializedAs("itemDescripcion")]
    public string ItemDescription;
    [FormerlySerializedAs("itemType")]
    public ItemTypeEnum ItemType;

    public enum ItemTypeEnum //declarar una lista de opciones
    {
        Materials,
        Tools,
        Components, //No se como ponerle a lo de la bombs pero va aquí
        Armor
    }
}
