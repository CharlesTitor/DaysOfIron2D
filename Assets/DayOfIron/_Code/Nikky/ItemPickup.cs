using UnityEngine;

public class ItemPickup : MonoBehaviour, IPickable
{
    public ItemData ItemData;
    [SerializeField] private float _pickupDistance = 5f;
    [SerializeField] private int _quantity = 1;
    [SerializeField] private Transform _playerPosition;


    private void OnMouseDown()
    {
        Debug.Log(Vector3.Distance(this.transform.position, _playerPosition.position) + " " + _pickupDistance);
        if (Vector3.Distance(this.transform.position, _playerPosition.position) <= _pickupDistance)
        {
            PickUp();
        }
    }

    public void PickUp()
    {
        Debug.Log("Picking Up");
        //InventoryManager.Instance.AddItem(ItemData, _quantity);
        if (ItemData.ItemName == "Iron")
        {
            Debug.Log("It's Iron");
            ItemsManager.Instance.AddIron(_quantity);
        }

        //InventoryManagerUI.Instance.RefreshInventoryUI();
        //HotbarManager.Instance.UpdateHotbar();

        Debug.Log("Destroying");
        Destroy(gameObject);
    }

    public void KeyItemGiver()
    {
        ItemsManager.Instance.AddBrokenBomb(_quantity);
    }
}
