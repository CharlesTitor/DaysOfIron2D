using System;
using UnityEngine.Serialization;

[Serializable]
public class Item
{
    public ItemData ItemData;
    [FormerlySerializedAs("itemQuantity")]
    public int ItemQuantity;
}