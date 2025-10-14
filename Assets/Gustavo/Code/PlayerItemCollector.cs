using UnityEngine;

public class PlayerItemCollector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private InventoryController inventoryController;
    void Start()
    {
        inventoryController = FindFirstObjectByType<InventoryController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
           Item item = collision.GetComponent<Item>();
           if(item !=null)
            {
                GameObject UIVariant = Instantiate( item.UIVariant);
                bool itemAdded = inventoryController.AddItem(UIVariant);

                if(itemAdded)
                {
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
