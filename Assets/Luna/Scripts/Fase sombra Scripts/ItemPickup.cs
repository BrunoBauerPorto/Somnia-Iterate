using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public int itemID;
    public string itemName;

    public void Pickup()
    {
               InventarioFaseSombra.Instance.AddItem(itemID, itemName);
        Destroy(gameObject);

    }

}
