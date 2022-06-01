using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private GameObject inventory;

    public enum property { usable, displayable, empty};
    public property itemProperty { get; set; }

    private string displayImage;

    public string combinationItem { get; private set; }

    public void OnPointerClick(PointerEventData eventData)
    {
        inventory.GetComponent<Inventory>().previousSlot = inventory.GetComponent<Inventory>().currentSlot;
        inventory.GetComponent<Inventory>().currentSlot = this.gameObject;
        Combine();
    }

    public void AssignProperty(int orderNumber, string displayImage, string combinationItem)
    {
        itemProperty = (property)orderNumber;
        this.displayImage = displayImage;
        this.combinationItem = combinationItem;
    }

    public void DisplayItem()
    {
        inventory.GetComponent<Inventory>().itemDisplayer.SetActive(true);
        inventory.GetComponent<Inventory>().itemDisplayer.GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Inventory_items/" + displayImage);
    }

    public void Combine()
    {
        if(inventory.GetComponent<Inventory>().previousSlot.GetComponent<Slot>().combinationItem ==
            this.gameObject.GetComponent<Slot>().combinationItem && this.gameObject.GetComponent<Slot>().combinationItem != "")
        {
            GameObject combinedItem = Instantiate(Resources.Load<GameObject>("Combined_Items/" + combinationItem));
            
            inventory.GetComponent<Inventory>().previousSlot.GetComponent<Slot>().ClearSlots();
            ClearSlots();

            combinedItem.GetComponent<PickupItem>().ItemPickUp(inventory.GetComponent<Inventory>().previousSlot);
        }
    }

    public void ClearSlots()
    {
        itemProperty = Slot.property.empty;
        displayImage = "";
        combinationItem = "";
        transform.GetChild(0).GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Inventory_items/empty_item");
    }
}
