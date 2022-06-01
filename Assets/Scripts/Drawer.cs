using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drawer : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject inventory;

    public string UnlockItem;
    

    public void Interact(DisplayImage currentDisplay)
    {
        if(inventory.GetComponent<Inventory>().currentSlot.transform.GetChild(0).GetComponent<Image>().sprite.name == UnlockItem)
        {
            Debug.Log("UnLock");
            //inventory.GetComponent<Inventory>().currentSlot.transform.GetChild(0).GetComponent<Image>().sprite =
            //    Resources.Load<Sprite>("Inventory_items/empty_item");
            //inventory.GetComponent<Inventory>().currentSlot.GetComponent<Slot>().itemProperty = Slot.property.empty;
            inventory.GetComponent<Inventory>().currentSlot.GetComponent<Slot>().ClearSlots();

        }
    }
}
