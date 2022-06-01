using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItem : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject slots;
    public enum property { usable, displayable };
    public string itemname;
    public property itemProperty;

    public string DisplayImage;

    public string CombinationItem;

    public void Interact(DisplayImage curreentDisplay)
    {
        ItemPickUp();
    }
    public void ItemPickUp()
    {
        foreach(Transform slot in slots.transform)
        {
            if (slot.transform.GetChild(0).GetComponent<Image>().sprite.name == "empty_item")
            {
                slot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory_items/" + itemname);
                slot.GetComponent<Slot>().AssignProperty((int)itemProperty, DisplayImage, CombinationItem);
                Destroy(gameObject);
                break;
            }
        }
    }
    public void ItemPickUp(GameObject slot)
    {
        slot.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory_items/" + itemname);
        slot.GetComponent<Slot>().AssignProperty((int)itemProperty, DisplayImage, CombinationItem);
        Destroy(gameObject);
    }
}
