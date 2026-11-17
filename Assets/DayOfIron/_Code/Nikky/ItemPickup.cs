using UnityEngine;
using UnityEngine.Serialization;

public class ItemPickup : MonoBehaviour, IPickable
{
    [FormerlySerializedAs("ItemData")]
    [SerializeField] private ItemData _itemData;
    [SerializeField] private float _pickupDistance = 5f;
    [SerializeField] private int _quantity = 1;
    [SerializeField] private Transform _playerPosition;

    [SerializeField] private ItemData _keyItemData;


    private void OnMouseDown()
    {
        Debug.Log(Vector3.Distance(this.transform.position, _playerPosition.position) + " " + _pickupDistance);
        if (Vector3.Distance(this.transform.position, _playerPosition.position)<=_pickupDistance)
        {
            PickUp();
        }
    }

    //Ya es aplicable a todos los objetos, no solo a iron
    public void PickUp()
    {
        if (InventoryManager.Instance==null)
        {
            return;
        }
        Debug.Log("Picking Up");
        InventoryManager.Instance.AddItem(_itemData, _quantity);
        Debug.Log("Destroying");
        Destroy(gameObject);
    }

    public void KeyItemGiver()
    {
        if (InventoryManager.Instance == null)
        {
            Debug.LogWarning("InventoryManager not found!");
            return;
        }

        InventoryManager.Instance.AddItem(_keyItemData, _quantity);

        Debug.Log("Key item received!");
    }
}
